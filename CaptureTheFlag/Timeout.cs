using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class Timeout
    {
        public static async void triggerTimeout()
        {
            await Task.Delay(Variables.getTimeOutSeconds() * 1000);
            Environment.Exit(0);
        }
    }
}
