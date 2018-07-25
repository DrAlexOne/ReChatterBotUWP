using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ReChatterBotUWP
{
    public static class AppSettings
    {

        public static string theme { get; set; } = "light";

        public static string Key { get; set; } = "TOKEN";

        public static string UserID { get; set; } = "0";

        public static bool Logged { get; set; } = false;

        public static int CheckCode { get; set; }

        public static TelegramBotClient client { get; set; } = new TelegramBotClient(AppSettings.Key);

        public static string UserName { get; set; } = "";

    }
}
