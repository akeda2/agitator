using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

using System.Runtime.InteropServices;


namespace openTray
{
    class closeTray
    {
        public static void Main()
        {
            int result = mciSendString
               ("set cdaudio door open", null, 0, IntPtr.Zero);
            result = mciSendString("set cdaudio door closed",
               null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi)]
        protected static extern int mciSendString
           (string mciCommand,
           StringBuilder returnValue,
           int returnLength,
           IntPtr callback);
    }
}