using Sticky.Util.Win32;
using Sticky.Util.Win32.MetroRadiance.Core.Win32;
using System;
using System.Runtime.InteropServices;

namespace Sticky.Util
{
    static class NativeMethods
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public static WSEX GetWindowLongEx(this IntPtr hWnd)
        {
            return (WSEX)NativeMethods.GetWindowLong(hWnd, (int)GWL.EXSTYLE);
        }

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public static WSEX SetWindowLongEx(this IntPtr hWnd, WSEX dwNewLong)
        {
            return (WSEX)NativeMethods.SetWindowLong(hWnd, (int)GWL.EXSTYLE, (int)dwNewLong);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP flags);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
    }
}
