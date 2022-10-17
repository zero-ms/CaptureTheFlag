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
        private static readonly string observingWindowName = "FIFA ONLINE 4";
        private static readonly string savePath = Environment.ExpandEnvironmentVariables("%public%\\savedCapture");
        private static readonly int monitorCount = SystemInformation.MonitorCount;
        private static readonly int checkDelayTime = 200;
        private static bool doCaptureCursor = true;
        private static readonly int timeOutSeoncds = 100;

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

        public static int getTimeOutSeconds()
        {
            return timeOutSeoncds;
        }
    }
}
