﻿using System;
using System.Collections.Generic;

namespace Fake64;

public partial class MOS6510
{
    private byte ASL(byte val)
    {
        Status = (byte)((Status & ~FLAG_C) | ((val & 0x80) >> 7));
        val <<= 1;
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte LSR(byte val)
    {
        Status = (byte)((Status & ~FLAG_C) | (val & 0x01));
        val >>= 1;
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte ROL(byte val)
    {
        bool carryIn = (Status & FLAG_C) != 0;
        bool carryOut = (val & 0x80) != 0;
        val = (byte)((val << 1) | (carryIn ? 1 : 0));
        Status = (byte)((Status & ~FLAG_C) | (carryOut ? FLAG_C : 0));
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte ROR(byte val)
    {
        bool carryIn = (Status & FLAG_C) != 0;
        bool carryOut = (val & 0x01) != 0;
        val = (byte)((val >> 1) | (carryIn ? 0x80 : 0));
        Status = (byte)((Status & ~FLAG_C) | (carryOut ? FLAG_C : 0));
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte INC(byte val)
    {
        val++;
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte DEC(byte val)
    {
        val--;
        SetZeroNegativeFlags(val);
        return val;
    }

    private byte ADC(byte val)
    {
        int result = A + val + ((Status & FLAG_C) != 0 ? 1 : 0);
        Status = (byte)((Status & ~(FLAG_C | FLAG_V)) |
                        (result > 0xFF ? FLAG_C : 0) |
                        (((A ^ result) & (val ^ result) & 0x80) != 0 ? FLAG_V : 0));
        A = (byte)result;
        SetZeroNegativeFlags(A);
        return A;
    }

    private byte SBC(byte val)
    {
        return ADC((byte)(~val));
    }

    private byte AND(byte val)
    {
        A &= val;
        SetZeroNegativeFlags(A);
        return A;
    }

    private byte EOR(byte val)
    {
        A ^= val;
        SetZeroNegativeFlags(A);
        return A;
    }

    private byte ORA(byte val)
    {
        A |= val;
        SetZeroNegativeFlags(A);
        return A;
    }

    private byte LDA(byte val)
    {
        A = val;
        SetZeroNegativeFlags(A);
        return A;
    }

    private byte LDX(byte val)
    {
        X = val;
        SetZeroNegativeFlags(X);
        return X;
    }

    private byte LDY(byte val)
    {
        Y = val;
        SetZeroNegativeFlags(Y);
        return Y;
    }

    private void BIT(byte val)
    {
        Status = (byte)((Status & ~(FLAG_Z | FLAG_N | FLAG_V)) |
                        (val & FLAG_N) |
                        (val & FLAG_V) |
                        ((A & val) == 0 ? FLAG_Z : 0));
    }


    private void JSR(ushort addr)
    {
        // Push the return address (PC - 1) onto the stack
        Push((byte)((PC + 2) >> 8)); // High byte
        Push((byte)(PC + 2));        // Low byte
        PC = addr;
    }

    private ushort RTS()
    {
        // Pull the return address from the stack
        byte low = Pop();
        byte high = Pop();
        return (ushort)((high << 8) | low);
    }

    private void RTI()
    {
        Status = (byte)(Pop() & ~FLAG_B);
        byte low = Pop();
        byte high = Pop();
        PC = (ushort)((high << 8) | low);
    }


    private byte SLO(ushort addr)
    {
        byte value = ASL(ReadByte(addr));
        WriteByte(addr, value);
        A = ORA(value);
        return A;
    }

    private byte RLA(ushort addr)
    {
        byte value = ROL(ReadByte(addr));
        WriteByte(addr, value);
        A = AND(value);
        return A;
    }

    private byte SRE(ushort addr)
    {
        byte value = LSR(ReadByte(addr));
        WriteByte(addr, value);
        A = EOR(value);
        return A;
    }

    private byte ISC(ushort addr)
    {
        byte value = INC(ReadByte(addr));
        WriteByte(addr, value);
        A = SBC(value);
        return A;
    }

    private void BRK()
    {
        // Simulate BRK instruction behavior
        Push((byte)(PC >> 8)); // Push high byte of PC
        Push((byte)PC);        // Push low byte of PC
        Push((byte)(Status | FLAG_B)); // Push status register with Break flag set
        Status |= FLAG_I;      // Set Interrupt Disable flag
        PC = ReadWord(0xFFFE); // Jump to interrupt vector
    }
    /// <summary>
    /// RRA - Illegal opcode that performs ROR followed by ADC on the same memory location
    /// </summary>
    /// <param name="address">The memory address to operate on</param>
    private void RRA(ushort address)
    {
        // Read the value from memory
        byte value = ReadByte(address);

        // Perform ROR (Rotate Right)
        byte rotatedValue = ROR(value);

        // Write the rotated value back to memory
        WriteByte(address, rotatedValue);

        // Perform ADC with the rotated value
        A = ADC(rotatedValue);
    }

    /// <summary>
    /// LAX - Illegal opcode that loads a value into both the Accumulator and X register
    /// </summary>
    /// <param name="value">The value to load</param>
    /// <returns>The loaded value</returns>
    private byte LAX(byte value)
    {
        // Set the zero and negative flags based on the value
        SetZN(value);

        // Return the value (which will be assigned to both A and X)
        return value;
    }
    /// <summary>
    /// DCP - Illegal opcode that performs DEC followed by CMP at the same memory location
    /// </summary>
    /// <param name="address">The memory address to operate on</param>
    private void DCP(ushort address)
    {
        // Read the value from memory
        byte value = ReadByte(address);

        // Decrement the value
        value--;

        // Write the decremented value back to memory
        WriteByte(address, value);

        // Compare the accumulator with the decremented value
        Compare(A, value);
    }
}