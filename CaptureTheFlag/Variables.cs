using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class Variables
    {
        private static string observingWindowName = "계산기";
        private static string savePath = Environment.ExpandEnvironmentVariables("%userprofile%\\savedCapture");
        private static int monitorCount = SystemInformation.MonitorCount;
        private static int checkDelayTime = 100;
        private static bool doCaptureCursor = true;

        public static string getObservingWindowName()
        {
            return observingWindowName;
        }

        public static string getSavePath()
        {
            return savePath;
        }

        public static int getMonitorCount()
        {
            return monitorCount;
        }

        public static int getDelayTime()
        {
            return checkDelayTime;
        }

        public static bool getCaptureCursor()
        {
            return doCaptureCursor;
        }
    }
}
