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
                lastSendUnixTime = Util.getUnixTime();
            }
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                {
                { "content", msg },
                { "username", "Logger-Error" },
                { "avatar_url", "https://w7.pngwing.com/pngs/595/505/png-transparent-computer-icons-error-closeup-miscellaneous-text-logo.png" }
                };
                client.PostAsync(discordHookURL, new FormUrlEncodedContent(contents)).GetAwaiter().GetResult();
            }
            catch
            {
                Console.WriteLine("[DEBUG] Logging-Error Error!");
            }
        }

        public static void sendInfo(string msg)
        {
            if (isCoolTime())
            {
                Thread.Sleep((int)getRemainingCoolTime());
                lastSendUnixTime = Util.getUnixTime();
            }
            try
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> contents = new Dictionary<string, string>
                {
                { "content", msg },
                { "username", "Logger-Info" },
                { "avatar_url", "https://e7.pngegg.com/pngimages/783/960/png-clipart-japanese-industrial-standards-logo-technical-standard-industry-info-ico-emblem-text-thumbnail.png" }
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
