using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class HelpCmd : Command
    {
        public override string Name => "/help";

        public override int Level => 0;

        private bool isOP(int id)
        {
            var list = Data.GetOP();
            if (list.Count < 1)
            {
                return false;
            }
            foreach (var opid in list)
            {
                if (id == Convert.ToInt32(opid))
                {
                    return true;
                }
            }
            return false;
        }

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string res = "Available commands for you, " + message.Chat.FirstName + " " + message.Chat.LastName + ":\n";
            res += Data.GetList();
            if (isOP(message.From.Id))
                res += Data.GetOPList();
            await client.SendTextMessageAsync(message.Chat.Id, res);
        }
    }
}