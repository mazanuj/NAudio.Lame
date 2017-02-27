using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NAudio.Lame
{
    /// <summary>
    /// Detect Operation System is 64bit | Detect Process is 64bit
    /// </summary>
    public static class Misc
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);

        /// <summary>
        /// Detect Operation System is 64bit
        /// </summary>
        /// <returns></returns>
        public static bool Is64BitOs()
        {
            using (var p = Process.GetCurrentProcess())
            {
                bool retVal;
                return IntPtr.Size == 8 ||
                       ( /*IsWow64Process != null && */
                           IntPtr.Size == 4 && IsWow64Process(p.Handle, out retVal) && retVal);
            }
        }

        /// <summary>
        /// Detect Process is 64bit
        /// </summary>
        /// <returns></returns>
        public static bool Is64BitProc()
        {
            return IntPtr.Size == 8;
        }
    }
}