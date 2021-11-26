using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static Fake64.StaticBasic;

namespace Fake64
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            byte[] screen_ram = new[] {
                (byte) 0xA0,(byte) 0xA0,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xEA,(byte) 0xD4,(byte) 0xC9,(byte) 0xCD,(byte) 0xC5,(byte) 0xF4,(byte) 0xA0,(byte) 0x35,(byte) 0x38,(byte) 0xA0,(byte) 0xEA,(byte) 0xD3,(byte) 0xC3,(byte) 0xCF,(byte) 0xD2,(byte) 0xC5,(byte) 0xF4,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xB0,(byte) 0xEA,(byte) 0xCC,(byte) 0xC1,(byte) 0xD0,(byte) 0xF4,(byte) 0xB0,(byte) 0xA7,(byte) 0xB1,(byte) 0xB7,(byte) 0xA2,(byte) 0xB2,(byte) 0xB9,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xA0,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xA0,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xEC,(byte) 0xE2,(byte) 0xE2,(byte) 0xFB,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xEC,(byte) 0xFF,(byte) 0xA2,(byte) 0xA0,(byte) 0x7F,(byte) 0xFB,(byte) 0xFB,(byte) 0xA0,(byte) 0xEC,(byte) 0xE2,(byte) 0xFB,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xF0,(byte) 0xEE,(byte) 0xE8,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xFE,(byte) 0xA7,(byte) 0xA0,(byte) 0xA7,(byte) 0xA2,(byte) 0xFC,(byte) 0xFC,(byte) 0xF9,(byte) 0xFF,(byte) 0xA2,(byte) 0x7F,(byte) 0xFB,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xED,(byte) 0xFD,(byte) 0x62,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xFE,(byte) 0xAE,(byte) 0xA2,(byte) 0x7F,(byte) 0xA0,(byte) 0xEC,(byte) 0x7F,(byte) 0xA0,(byte) 0xA0,(byte) 0x7F,(byte) 0xA0,(byte) 0xA2,(byte) 0xFF,(byte) 0xEF,(byte) 0xA0,(byte) 0xA0,(byte) 0x61,(byte) 0xDC,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xAE,(byte) 0xE8,(byte) 0xBA,(byte) 0xA5,(byte) 0xBB,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xAC,(byte) 0x7F,(byte) 0xFE,(byte) 0xA7,(byte) 0xFF,(byte) 0xA0,(byte) 0xF0,(byte) 0xEE,(byte) 0xE8,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xE6,(byte) 0xBA,(byte) 0xA3,(byte) 0xE9,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xEC,(byte) 0xAE,(byte) 0xBA,(byte) 0xBA,(byte) 0xAC,(byte) 0xA0,(byte) 0xBA,(byte) 0xA2,(byte) 0xFB,(byte) 0xED,(byte) 0xFD,(byte) 0x62,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xFF,(byte) 0xE6,(byte) 0xE9,(byte) 0xEC,(byte) 0xE8,(byte) 0xE8,(byte) 0xE8,(byte) 0xBA,(byte) 0xA3,(byte) 0xE6,(byte) 0xE8,(byte) 0xFE,(byte) 0xA5,(byte) 0xE8,(byte) 0xE8,(byte) 0xFC,(byte) 0xE8,(byte) 0xE8,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,(byte) 0xE4,
                (byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xDC,(byte) 0xDE,(byte) 0x69,(byte) 0xA0,(byte) 0xDC,(byte) 0xE9,(byte) 0xA0,(byte) 0xA0,(byte) 0xAA,(byte) 0xAE,(byte) 0xBA,(byte) 0xA7,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xF5,(byte) 0xAE,(byte) 0xBA,(byte) 0xA2,(byte) 0xA0,(byte) 0xAE,(byte) 0xBA,(byte) 0xA0,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xAE,(byte) 0xBA,(byte) 0xA2,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xBA,(byte) 0xA2,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xE4,(byte) 0xEF,(byte) 0xEF,(byte) 0xA0,(byte) 0xEF,(byte) 0xEF,(byte) 0xE4,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x5C,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xBA,(byte) 0xA2,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xEC,(byte) 0xBC,(byte) 0x9B,(byte) 0x9D,(byte) 0xF7,(byte) 0xA8,(byte) 0xA9,(byte) 0xBE,(byte) 0xFB,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xAE,(byte) 0xBA,(byte) 0xA2,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xA0,(byte) 0xA8,(byte) 0xE6,(byte) 0xE8,(byte) 0xE8,(byte) 0xE8,(byte) 0xE8,(byte) 0xE8,(byte) 0xE6,(byte) 0xA9,(byte) 0xA0,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA2,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0x0F,(byte) 0x0F,(byte) 0x64,(byte) 0x64,(byte) 0x25,(byte) 0x64,(byte) 0x64,(byte) 0x0F,(byte) 0x0F,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA2,(byte) 0xBA,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xDF,(byte) 0x9D,(byte) 0xAA,(byte) 0xD3,(byte) 0xC8,(byte) 0xCE,(byte) 0xAA,(byte) 0x9B,(byte) 0xE9,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xAE,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0x62,(byte) 0x62,(byte) 0xF7,(byte) 0xE3,(byte) 0xE3,(byte) 0xE3,(byte) 0xF7,(byte) 0x62,(byte) 0x62,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xBA,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0x81,(byte) 0xCE,(byte) 0x84,(byte) 0x99,
                (byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x30,(byte) 0x30,(byte) 0x30,(byte) 0xA0,(byte) 0x0B,(byte) 0x0D,(byte) 0x2F,(byte) 0x08,(byte) 0xA0,(byte) 0x31,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0x53,(byte) 0x54,(byte) 0x41,(byte) 0x47,(byte) 0x45,(byte) 0xA0,(byte) 0x31,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,
                (byte) 0xA0,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0x75,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0,(byte) 0xA0
            };

            byte[] colour_ram = new[] {
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0x22,(byte) 0x22,(byte) 0xEE,(byte) 0x77,(byte) 0xEE,(byte) 0x44,(byte) 0x44,(byte) 0x4E,(byte) 0x33,(byte) 0x33,(byte) 0x33,(byte) 0x33,(byte) 0xE6,(byte) 0x66,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xE1,(byte) 0x11,(byte) 0x1E,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xD5,(byte) 0xE1,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,
                (byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0x1E,(byte) 0x11,(byte) 0x1E,(byte) 0xEE,(byte) 0xEE,(byte) 0x55,(byte) 0xE0,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,
                (byte) 0x55,(byte) 0x51,(byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xE1,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,
                (byte) 0x55,(byte) 0x55,(byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0x11,(byte) 0xEE,(byte) 0xD5,(byte) 0xE0,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,(byte) 0x10,
                (byte) 0x55,(byte) 0x55,(byte) 0x11,(byte) 0x11,(byte) 0x55,(byte) 0x11,(byte) 0x11,(byte) 0x1E,(byte) 0x55,(byte) 0xE1,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,(byte) 0x01,
                (byte) 0x55,(byte) 0x55,(byte) 0x11,(byte) 0x15,(byte) 0x55,(byte) 0x15,(byte) 0x51,(byte) 0x11,(byte) 0x1E,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,(byte) 0xEE,
                (byte) 0xC8,(byte) 0xCC,(byte) 0xCC,(byte) 0xC5,(byte) 0x55,(byte) 0xC5,(byte) 0x5C,(byte) 0xC5,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,
                (byte) 0xF8,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0x8F,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,
                (byte) 0xC8,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0x8C,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,
                (byte) 0xF8,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,
                (byte) 0xC8,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0x2A,(byte) 0xAC,(byte) 0x77,(byte) 0x2C,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,
                (byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xF2,(byte) 0x22,(byte) 0x22,(byte) 0x22,(byte) 0x22,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,
                (byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xC2,(byte) 0xA2,(byte) 0x2A,(byte) 0x22,(byte) 0xA2,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,
                (byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xF2,(byte) 0x22,(byte) 0xAA,(byte) 0xA2,(byte) 0x22,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,(byte) 0xFF,
                (byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,(byte) 0xCC,
                (byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,
                (byte) 0x02,(byte) 0x22,(byte) 0x07,(byte) 0x77,(byte) 0x70,(byte) 0x50,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x77,(byte) 0x77,(byte) 0x70,(byte) 0x70,(byte) 0x00,
                (byte) 0x03,(byte) 0x33,(byte) 0x35,(byte) 0x55,(byte) 0x44,(byte) 0x40,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00,(byte) 0x00
            };

            POKE(0xD020, 13);
            POKE(0xD021, 14);
            for (ushort addr = 0x0400; addr < 0x0400 + 0x3E8 ; addr++)
            {
                POKE(addr, 32);
            }
            var i = 0;
            for (ushort addr = 0x0400; addr < 0x0400 + 0x100; addr++)
            {
                POKE(addr, (byte) i++);
            }
            byte color = 0;
            for (ushort addr = 0xD800; addr < 0xD800 + 0x3E8; addr++)
            {
                POKE(addr, color);
                color = (byte) ((color + 1) & 0xf);
            }

            var form = new Fake64Form();
            form.KeyDown += (s, e) => {

                switch (e.KeyCode)
                {
                    default:
                        break;
                }
            
            };
            form.KeyUp += (s, e) => {

                switch (e.KeyCode)
                {
                    default:
                        break;
                }

            };
            form.Show();

            var refrate = 50;

            var timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)Math.Round(1000.0 / refrate, 0);
            timer.Tick += (s, e) =>
            {
                var start = DateTime.Now;

                form.Render();

                // do something

                var stop = DateTime.Now;
                var frameRate = (int)Math.Round(1000.0 / (stop - start).TotalMilliseconds, 0);
            };
            timer.Start();

            Application.Run(form);
        }
    }
}
