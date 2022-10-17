using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CaptureTheFlag
{
    internal class Logger
    {
        private static readonly string discordHookURL = "https://discord.com/api/webhooks/1026490370781085778/8sPBYd53um6oIfoInpZ2Ii2t2Pb6kR0QO5Ke36qTVJisDV-6ZsKPN9eqBwWKteu6r0Dk";

        public static void sendError(string msg)
        {
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
    }
}
