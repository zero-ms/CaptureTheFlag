using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureTheFlag
{
    internal class Logger
    {
        private static readonly string discordHookURL = "https://discord.com/api/webhooks/1026490370781085778/8sPBYd53um6oIfoInpZ2Ii2t2Pb6kR0QO5Ke36qTVJisDV-6ZsKPN9eqBwWKteu6r0Dk";
        private static long lastSendUnixTime = 0;
        private static readonly int sendCoolTime = 1500;

        public static void sendError(string msg)
        {
            if (isCoolTime())
            {
                Thread.Sleep((int)getRemainingCoolTime());
            }
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                {
                { "content", msg },
                { "username", "Logger-Error" },
                { "avatar_url", "https://www.freeiconspng.com/thumbs/error-icon/error-icon-32.png" }
                };
                client.PostAsync(discordHookURL, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch
            {
                Console.WriteLine("[DEBUG] Logging-Error Error!");
            }
        }

        private static bool isCoolTime()
        {
            if (lastSendUnixTime == 0)
            {
                lastSendUnixTime = Util.getUnixTime();
                return false;
            }
            else
            {
                return Util.getUnixTime() - lastSendUnixTime > sendCoolTime ? false : true;
            }
        }

        private static long getRemainingCoolTime()
        {
            long remainingCoolTime = sendCoolTime - (Util.getUnixTime() - lastSendUnixTime);
            return remainingCoolTime > 0 ? remainingCoolTime : 500;
        }
    }
}
