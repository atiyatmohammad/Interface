using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static students.Program;

namespace students
{
    internal class ChangeFontSize
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Int32 SetCurrentConsoleFontEx(
        IntPtr ConsoleOutput,
        bool MaximumWindow,
        ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx);

        private enum StdHandle
        {
            OutputHandle = -11
        }
        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);
        public void changefont()
        {
            // Setting the font and fontsize
            // Other values can be changed too
            /*
            begin:
                Console.Clear();
                Console.Write("Before. Press any key to continue");
                Console.ReadKey();
                Console.WriteLine();

            tryagain:
                Console.WriteLine("enter font x Value: ");
                string input = Console.ReadLine();
                if (short.TryParse(input, out short x))
                {
                    goto trysecond;
                }
                else
                {
                    Console.WriteLine($"Invalid Value {Console.Error}");
                    goto tryagain;
                }

            trysecond:
                Console.WriteLine("enter font x Value: ");
                input = Console.ReadLine();
                if (short.TryParse(input, out short y))
                {
                    goto continue1;
                }
                else
                {
                    Console.WriteLine($"Invalid Value {Console.Error}");
                    goto trysecond;
                }

            continue1:*/
            //Instantiating CONSOLE_FONT_INFO_EX and setting its size (the function will fail otherwise)

            CONSOLE_FONT_INFO_EX ConsoleFontInfo = new CONSOLE_FONT_INFO_EX();
            ConsoleFontInfo.cbSize = (uint)Marshal.SizeOf(ConsoleFontInfo);

            // Optional, implementing this will keep the fontweight and fontsize from changing
            // See notes
            // GetCurrentConsoleFontEx(GetStdHandle(StdHandle.OutputHandle), false, ref ConsoleFontInfo);

            ConsoleFontInfo.FaceName = "Lucida Console";
            ConsoleFontInfo.dwFontSize.X = 10;
            ConsoleFontInfo.dwFontSize.Y = 20;
            //ConsoleFontInfo.dwFontSize.X = x;
           // ConsoleFontInfo.dwFontSize.Y = y;

            SetCurrentConsoleFontEx(GetStdHandle(StdHandle.OutputHandle), false, ref ConsoleFontInfo);

           // Console.Clear();
           // Console.Write("After. Notice how the font type and size changed?");
           // Console.ReadKey();
           // goto begin;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;

            public COORD(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CONSOLE_FONT_INFO_EX
        {
            public uint cbSize;
            public uint nFont;
            public COORD dwFontSize;
            public int FontFamily;
            public int FontWeight;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] // Edit sizeconst if the font name is too big
            public string FaceName;
        }
    }
}
