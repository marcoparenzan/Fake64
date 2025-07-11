using Fake64;

public class MOS6526
{
    Board board;
    private byte id;

    // Registers
    private byte dataPortA; // $DC00/DD00
    private byte dataPortB; // $DC01/DD01
    private byte dataDirectionA; // $DC02/DD02
    private byte dataDirectionB; // $DC03/DD03
    private ushort timerA; // $DC04-$DC05/DD04-DD05
    private ushort timerB; // $DC06-$DC07/DD06-DD07
    private byte tod10thsec; // $DC08/DD08
    private byte todSec; // $DC09/DD09
    private byte todMin; // $DC0A/DD0A
    private byte todHr; // $DC0B/DD0B
    private byte serialShift; // $DC0C/DD0C
    private byte interruptControl; // $DC0D/DD0D (ICR)
    private byte controlRegA; // $DC0E/DD0E (CRA)
    private byte controlRegB; // $DC0F/DD0F (CRB)

    // Timer latches
    private ushort timerALatch;
    private ushort timerBLatch;

    // TOD latches
    private byte todAlarm10thsec;
    private byte todAlarmSec;
    private byte todAlarmMin;
    private byte todAlarmHr;

    // Status flags
    private bool timerARunning;
    private bool timerBRunning;
    private bool todRunning;
    private bool serialRunning;
    private byte interruptStatus; // Internal interrupt status

    // Cycle-exact signal tracking
    private bool pendingTimerAUnderflow;
    private bool pendingTimerBUnderflow;
    private bool pendingTodAlarm;
    private byte pendingInterrupts;
    private int todCycleDivider;
    private const int TOD_CYCLE_INTERVAL = 19656; // PAL cycles for 1/10 second (50Hz system)

    public MOS6526(Board board, byte id)
    {
        this.board = board;
        this.id = id;
        Reset();
    }

    public void Reset()
    {
        // Clear all registers
        dataPortA = dataPortB = 0;
        dataDirectionA = dataDirectionB = 0;
        timerA = timerB = 0;
        timerALatch = timerBLatch = 0;
        tod10thsec = todSec = todMin = todHr = 0;
        todAlarm10thsec = todAlarmSec = todAlarmMin = todAlarmHr = 0;
        serialShift = 0;
        interruptControl = 0;
        controlRegA = controlRegB = 0;
        interruptStatus = 0;

        // Reset status flags
        timerARunning = timerBRunning = false;
        todRunning = true; // TOD clock starts running
        serialRunning = false;

        // Reset cycle-exact tracking
        pendingTimerAUnderflow = false;
        pendingTimerBUnderflow = false;
        pendingTodAlarm = false;
        pendingInterrupts = 0;
        todCycleDivider = 0;

        // If this is CIA1, configure it for system timing
        if (id == 1)
        {
            // Set Timer A for ~60Hz jiffy interrupt
            // 985248 Hz (PAL clock) / 60 Hz ? 16421
            timerALatch = 16421; // Use 16421 for PAL, 17045 for NTSC
            timerA = timerALatch;

            // Start Timer A in continuous mode and generate interrupts
            controlRegA = 0x01; // Bit 0: Start timer
            interruptControl = 0x81; // Bit 0: Enable Timer A interrupts, Bit 7: Set mask bit
            timerARunning = true;
        }
    }

    internal void ProcessSignals(int currentCycle)
    {
        // Process Timer A
        if (timerARunning)
        {
            // Will timer A underflow in the next cycle?
            if (timerA == 1)
            {
                pendingTimerAUnderflow = true;
            }
        }

        // Process Timer B
        bool timerBClockByUnderflow = (controlRegB & 0x40) != 0;
        if (timerBRunning && (!timerBClockByUnderflow || pendingTimerAUnderflow))
        {
            // Will timer B underflow in the next cycle?
            if ((timerBClockByUnderflow && pendingTimerAUnderflow && timerB == 1) ||
                (!timerBClockByUnderflow && timerB == 1))
            {
                pendingTimerBUnderflow = true;
            }
        }

        // Process TOD clock - only increment at 1/10 second intervals
        todCycleDivider++;
        if (todCycleDivider >= TOD_CYCLE_INTERVAL)
        {
            todCycleDivider = 0;

            // Will TOD match alarm in the next cycle?
            byte next10th = (byte)((tod10thsec + 1) % 10);
            if (todRunning &&
                next10th == todAlarm10thsec &&
                todSec == todAlarmSec &&
                todMin == todAlarmMin &&
                todHr == todAlarmHr)
            {
                pendingTodAlarm = true;
            }
        }

        // Process serial port - simplified, would need more for real serial I/O
        // Handle keyboard/joystick inputs for CIA 1
        if (id == 1)
        {
            // Keyboard matrix is handled via GetCIAPort in the Board class
        }

        // Prepare pending interrupts
        if (pendingTimerAUnderflow && (interruptControl & 0x01) != 0)
            pendingInterrupts |= 0x01;

        if (pendingTimerBUnderflow && (interruptControl & 0x02) != 0)
            pendingInterrupts |= 0x02;

        if (pendingTodAlarm && (interruptControl & 0x04) != 0)
            pendingInterrupts |= 0x04;
    }

    public void Clock(long ticks)
    {
        // Handle Timer A
        if (timerARunning)
        {
            timerA--;

            if (pendingTimerAUnderflow)
            {
                // Timer A underflow
                if ((controlRegA & 0x08) == 0) // One-shot mode?
                {
                    timerARunning = false;
                    controlRegA &= 0xFE; // Clear bit 0
                }

                // Reload from latch
                timerA = timerALatch;

                // Set interrupt flag
                interruptStatus |= 0x01;

                // Clear pending signal
                pendingTimerAUnderflow = false;
            }
        }

        // Handle Timer B
        if (timerBRunning)
        {
            bool timerBClockByUnderflow = (controlRegB & 0x40) != 0;

            // Only decrement if we're not counting underflows, or if we had an underflow
            if (!timerBClockByUnderflow || pendingTimerAUnderflow)
            {
                timerB--;
            }

            if (pendingTimerBUnderflow)
            {
                // Timer B underflow handling
                if ((controlRegB & 0x08) == 0) // One-shot mode?
                {
                    timerBRunning = false;
                    controlRegB &= 0xFE; // Clear bit 0
                }

                // Reload from latch
                timerB = timerBLatch;

                // Set interrupt flag
                interruptStatus |= 0x02;

                // Clear pending signal
                pendingTimerBUnderflow = false;
            }
        }

        // Handle TOD clock update
        if (todCycleDivider == 0 && todRunning)
        {
            // Update TOD clock registers
            tod10thsec = (byte)((tod10thsec + 1) % 10);

            if (tod10thsec == 0)
            {
                todSec = (byte)((todSec + 1) % 60);

                if (todSec == 0)
                {
                    todMin = (byte)((todMin + 1) % 60);

                    if (todMin == 0)
                    {
                        todHr = (byte)((todHr + 1) % 24);
                    }
                }
            }

            if (pendingTodAlarm)
            {
                // Set alarm interrupt
                interruptStatus |= 0x04;
                pendingTodAlarm = false;
            }
        }

        // Process any pending interrupts
        if (pendingInterrupts != 0)
        {
            // Update internal interrupt status
            interruptStatus |= pendingInterrupts;
            pendingInterrupts = 0;

            CheckInterrupts();
        }
    }

    private void CheckInterrupts()
    {
        // Check if any enabled interrupt has occurred
        if ((interruptStatus & interruptControl & 0x1F) != 0)
        {
            // Set the IRQ flag
            interruptStatus |= 0x80;

            // Signal interrupt to CPU
            board.CIATriggerInterrupt(id);
        }
    }

    public byte Address(ushort addr)
    {
        // Mask to get register index (0-15)
        byte register = (byte)(addr & 0x0F);

        switch (register)
        {
            case 0x00: return (byte)(board.GetCIAPort(id, 'A') & ~dataDirectionA); // Port A
            case 0x01: return (byte)(board.GetCIAPort(id, 'B') & ~dataDirectionB); // Port B
            case 0x02: return dataDirectionA; // DDRA
            case 0x03: return dataDirectionB; // DDRB
            case 0x04: return (byte)(timerA & 0xFF); // Timer A low
            case 0x05: return (byte)(timerA >> 8); // Timer A high
            case 0x06: return (byte)(timerB & 0xFF); // Timer B low
            case 0x07: return (byte)(timerB >> 8); // Timer B high
            case 0x08: return tod10thsec; // TOD 10ths
            case 0x09: return todSec; // TOD seconds
            case 0x0A: return todMin; // TOD minutes
            case 0x0B: return todHr; // TOD hours
            case 0x0C: return serialShift; // Serial port
            case 0x0D: // Interrupt Control Register (ICR)
                byte temp = interruptStatus;
                interruptStatus &= 0x7F; // Clear bit 7
                return temp;
            case 0x0E: return controlRegA; // Control register A
            case 0x0F: return controlRegB; // Control register B
            default: return 0xFF;
        }
    }

    public void Address(ushort addr, byte value)
    {
        // Mask to get register index (0-15)
        byte register = (byte)(addr & 0x0F);

        switch (register)
        {
            case 0x00: // Port A
                dataPortA = value;
                board.SetCIAPort(id, 'A', value);
                break;
            case 0x01: // Port B
                dataPortB = value;
                board.SetCIAPort(id, 'B', value);
                break;
            case 0x02: // DDRA
                dataDirectionA = value;
                break;
            case 0x03: // DDRB
                dataDirectionB = value;
                break;
            case 0x04: // Timer A low
                timerALatch = (ushort)((timerALatch & 0xFF00) | value);
                break;
            case 0x05: // Timer A high
                timerALatch = (ushort)((value << 8) | (timerALatch & 0x00FF));
                if ((controlRegA & 0x01) == 0) // Timer stopped
                {
                    timerA = timerALatch;
                }
                break;
            case 0x06: // Timer B low
                timerBLatch = (ushort)((timerBLatch & 0xFF00) | value);
                break;
            case 0x07: // Timer B high
                timerBLatch = (ushort)((value << 8) | (timerBLatch & 0x00FF));
                if ((controlRegB & 0x01) == 0) // Timer stopped
                {
                    timerB = timerBLatch;
                }
                break;
            case 0x08: // TOD 10ths or Alarm 10ths
                if ((controlRegB & 0x80) != 0)
                    todAlarm10thsec = (byte)(value & 0x0F);
                else
                    tod10thsec = (byte)(value & 0x0F);
                break;
            case 0x09: // TOD seconds or Alarm seconds
                if ((controlRegB & 0x80) != 0)
                    todAlarmSec = (byte)(value & 0x7F);
                else
                    todSec = (byte)(value & 0x7F);
                break;
            case 0x0A: // TOD minutes or Alarm minutes
                if ((controlRegB & 0x80) != 0)
                    todAlarmMin = (byte)(value & 0x7F);
                else
                    todMin = (byte)(value & 0x7F);
                break;
            case 0x0B: // TOD hours or Alarm hours
                if ((controlRegB & 0x80) != 0)
                    todAlarmHr = (byte)(value & 0x9F);
                else
                {
                    todHr = (byte)(value & 0x9F);
                    todRunning = true;
                }
                break;
            case 0x0C: // Serial port
                serialShift = value;
                break;
            case 0x0D: // Interrupt Control Register
                if ((value & 0x80) != 0)
                {
                    // Set bits
                    interruptControl |= (byte)(value & 0x7F);
                }
                else
                {
                    // Clear bits
                    interruptControl &= (byte)~value;
                }
                CheckInterrupts();
                break;
            case 0x0E: // Control register A
                controlRegA = value;
                if ((value & 0x01) != 0) // Start bit set
                {
                    timerARunning = true;
                    if ((value & 0x10) != 0) // Force load bit set
                    {
                        timerA = timerALatch;
                    }
                }
                else
                {
                    timerARunning = false;
                }
                break;
            case 0x0F: // Control register B
                controlRegB = value;
                if ((value & 0x01) != 0) // Start bit set
                {
                    timerBRunning = true;
                    if ((value & 0x10) != 0) // Force load bit set
                    {
                        timerB = timerBLatch;
                    }
                }
                else
                {
                    timerBRunning = false;
                }
                break;
        }
    }
}