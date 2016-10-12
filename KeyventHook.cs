using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keyvent
{
    class KeyventHookEventArgs : HandledEventArgs
    {
        public int Flags { get; set; }

        public int VirtualKeyCode { get; set; }

        public int Message { get; set; }

        public int ScanCode { get; set; }

        public bool StateAlt { get; set; }

        public bool StateControl { get; set; }

        public bool StateShift { get; set; }

        public bool StateWindows { get; set; }
    }

    class KeyventHook : IDisposable
    {
        public event EventHandler<KeyventHookEventArgs> KeyPressed;

        private const int WH_KEYBOARD_LL = 13;

        public const int WM_KEYDOWN = 0x0100;

        public const int WM_KEYUP = 0x0101;

        public const int WM_SYSKEYDOWN = 0x0104;

        public const int WM_SYSKEYUP = 0x0105;

        private IntPtr HookID = IntPtr.Zero;

        public KeyventHook()
        {
            using (var process = Process.GetCurrentProcess())
            {
                using (var module = process.MainModule)
                {
                    HookID = SetWindowsHookEx(WH_KEYBOARD_LL, HookCallback, GetModuleHandle(module.ModuleName), 0);
                }
            }
        }

        public void Dispose()
        {
            UnhookWindowsHookEx(HookID);
        }

        private IntPtr HookCallback(int code, IntPtr wparam, IntPtr lparam)
        {
            int message = wparam.ToInt32();
            if ((code >= 0) && ((message == WM_KEYDOWN) || (message == WM_KEYUP) || (message == WM_SYSKEYDOWN) || (message == WM_SYSKEYUP)))
            {
                KeyPressed?.Invoke(this, new KeyventHookEventArgs
                {
                    Message = message,
                    VirtualKeyCode = Marshal.ReadInt32(lparam),
                    ScanCode = Marshal.ReadInt32(lparam),
                    Flags = Marshal.ReadInt32(lparam),
                    StateAlt = ((GetAsyncKeyState(Keys.LMenu) < 0) || (GetAsyncKeyState(Keys.RMenu) < 0)),
                    StateControl = ((GetAsyncKeyState(Keys.LControlKey) < 0) || (GetAsyncKeyState(Keys.RControlKey) < 0)),
                    StateShift = ((GetAsyncKeyState(Keys.LShiftKey) < 0) || (GetAsyncKeyState(Keys.RShiftKey) < 0)),
                    StateWindows = ((GetAsyncKeyState(Keys.LWin) < 0) || (GetAsyncKeyState(Keys.RWin) < 0)),
                });
            }
            return CallNextHookEx(HookID, code, wparam, lparam);
        }

        /// <summary>
        /// Reference: https://blogs.msdn.microsoft.com/toub/2006/05/03/low-level-keyboard-hook-in-c/
        /// </summary>
        private delegate IntPtr LowLevelKeyboardProc(int code, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc lpfn, IntPtr module, uint thread);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int code, IntPtr wparam, IntPtr lparam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string module);
    }
}
