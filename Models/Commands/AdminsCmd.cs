using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class AdminsCmd : Command
    {
        public override string Name => "/admins";

        public override int Level => 1;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string res = "Admins\' IDs:";
            foreach (var id in Data.GetOP())
            {
                res += "\n" + id;
            }
            await client.SendTextMessageAsync(message.Chat.Id, res);
        }
    }
}