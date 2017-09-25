using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace KioskSampleApp
{
    public static class KeyboardManager
    {
        #region methods

        public static void LaunchOnScreenKeyboard()
        {
            var processes = Process.GetProcessesByName("osk").ToArray();
            if (processes.Any())
                return;
            var keyboardManagerPath = "KeyboardExecuter.exe";
            Process.Start(keyboardManagerPath);
        }

        public static void KillOnScreenKeyboard()
        {
            var processes = Process.GetProcessesByName("osk").ToArray();
            foreach (var proc in processes)
            {
                proc.Kill();
            }
        }

        #endregion
    }
}
