using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal static class Program
    {
        static void Main()
        {
            Watchdog.startObserving();
        }
    }
}
