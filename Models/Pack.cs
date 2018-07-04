using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SourceryWeb.Models
{
    public struct Pack
    {
        public Telegram.Bot.Types.Message msg;
        public Telegram.Bot.TelegramBotClient client;
        public string dest;
    }
}