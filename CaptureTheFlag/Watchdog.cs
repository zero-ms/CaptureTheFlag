using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaptureTheFlag
{
    internal class Watchdog
    {
        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        public static void startObserving()
        {
            initSetting();
            while (true)
            {
                if (isWindowMatched(getForegroundWindowName()))
                {
                    Console.WriteLine("[DEBUG] Screen Saved!");
                    ScreenCapture.doCaptureAndSave();
                }
                Thread.Sleep(Variables.getDelayTime());
            }
        }

        private static void initSetting()
        {
            initSaveDirectory();
        }

        private static void initSaveDirectory()
        {
            DirectoryInfo saveDirectory = new DirectoryInfo(Variables.getSavePath());
            if (!saveDirectory.Exists)
            {
                saveDirectory.Create();
            }

            for (int i = 1; i <= Variables.getMonitorCount(); i++)
            {
                saveDirectory = new DirectoryInfo(Variables.getSavePath() + "\\" + i);
                if (!saveDirectory.Exists)
                {
                    saveDirectory.Create();
                }
            }
        }

        private static string getForegroundWindowName()
        {
            const int nChars = 256;
            int handle = 0;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            else
            {
                return "error!";
            }
        }

        public static Boolean isWindowMatched(string windowName)
        {
            if (windowName.Contains(Variables.getObservingWindowName()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
