using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class AddPromoCmd : Command
    {
        public override string Name => "/addpromo";

        public override int Level => 1;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (message.Text.Length < 11)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            string raw = message.Text.Substring(10, message.Text.Length - 10);
            Data.AddPromo(raw);
            var res = new Promo(raw);
            await client.SendTextMessageAsync(message.Chat.Id, "Promocode " + res.val + " added!");
        }
    }
}