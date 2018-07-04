using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class GetPromosCmd : Command
    {
        public override string Name => "/getpromos";
        public override int Level => 1;
        public override async void Execute(Message message, TelegramBotClient client)
        {
            IReadOnlyList<Promo> res = Data.GetPromos();
            string reply = "";
            foreach (var str in res)
            {
                reply += str.val + "  " + str.link + "\n";
            }
            await client.SendTextMessageAsync(message.Chat.Id, reply);
        }
    }
}