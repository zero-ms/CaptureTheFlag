using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class ProcessManager
    {
        public static void terminateProcess(string processImageName)
        {
            Process[] processes = Process.GetProcessesByName(processImageName);

            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}
