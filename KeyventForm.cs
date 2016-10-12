using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keyvent
{
    public partial class KeyventForm : Form
    {
        private KeyventHook Hook;

        private DateTime LastUpdate;

        public KeyventForm()
        {
            InitializeComponent();
        }

        private void ClearTimer_Tick(object sender, EventArgs e)
        {
            if ((LastUpdate != null) && ((DateTime.Now - LastUpdate).TotalSeconds > 5)) ShortcutLabel.Text = null;
        }

        private void Hook_Keypressed(object sender, KeyventHookEventArgs e)
        {
            var key = (Keys)e.VirtualKeyCode;
            if ((e.Message == KeyventHook.WM_KEYDOWN) || (e.Message == KeyventHook.WM_SYSKEYDOWN))
            {
                var keys = new List<Keys>();
                if (e.StateControl) keys.Add(Keys.Control);
                if (e.StateShift) keys.Add(Keys.Shift);
                if (e.StateAlt) keys.Add(Keys.Menu);
                if (e.StateWindows) keys.Add(Keys.LWin);
                if (keys.Count >= 1)
                {
                    keys.Add(key);
                    LastUpdate = DateTime.Now;
                    ShortcutLabel.Text = string.Join(" + ", keys.Select(i => GetKeyDisplayText(i)));
                }
            }
        }

        private void KeyventForm_FormClosing(object sender, FormClosingEventArgs e) => Hook.Dispose();

        private void KeyventForm_Load(object sender, EventArgs e)
        {
            Hook = new KeyventHook();
            Hook.KeyPressed += Hook_Keypressed;
            Location = new Point
            {
                X = 0, // Screen.PrimaryScreen.WorkingArea.Width - Width,
                Y = Screen.PrimaryScreen.WorkingArea.Height - Height,
            };
            KeyventTrayIcon.ShowBalloonTip(1 * 1000);
        }

        private void TrayMenuExitItem_Click(object sender, EventArgs e) => Close();

        private static string GetKeyDisplayText(Keys key)
        {
            switch (key)
            {
                // Alphabets
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                // Function
                case Keys.F1:
                case Keys.F2:
                case Keys.F3:
                case Keys.F4:
                case Keys.F5:
                case Keys.F6:
                case Keys.F7:
                case Keys.F8:
                case Keys.F9:
                case Keys.F10:
                case Keys.F11:
                case Keys.F12:
                // Arrow
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                // Special
                case Keys.Enter:
                case Keys.Escape:
                case Keys.Space:
                case Keys.Tab:
                    return key.ToString();
                case Keys.Back:
                    return "Back Space";
                // Numbers
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.D0:
                    return "0";
                // Modifiers
                case Keys.Menu:
                    return "Alt";
                case Keys.Control:
                    return "Ctrl";
                case Keys.LWin:
                    return "Win";
                case Keys.Shift:
                    return "Shift";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Reference: http://stackoverflow.com/questions/1524035/topmost-form-clicking-through-possible#answer-1524047
        /// </summary>
        private void KeyventToastForm_Shown(object sender, EventArgs e)
        {
            int wl = GetWindowLong(Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(Handle, GWL.ExStyle, wl);
            SetLayeredWindowAttributes(Handle, 0, 128, LWA.Alpha);
        }

        public enum GWL
        {
            ExStyle = -20
        }

        public enum WS_EX
        {
            Transparent = 0x20,
            Layered = 0x80000
        }

        public enum LWA
        {
            ColorKey = 0x1,
            Alpha = 0x2
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, GWL nindex);

        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte alpha, LWA dwflags);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, GWL nindex, int dwnewlong);
    }
}
