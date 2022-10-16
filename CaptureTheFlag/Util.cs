using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class Util
    {
        public static long getUnixTime()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}
