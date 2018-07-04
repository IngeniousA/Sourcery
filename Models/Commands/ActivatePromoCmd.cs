using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace SourceryWeb.Models.Commands
{
    public class ActivatePromoCmd : Command
    {
        public override string Name => "/activate";
        public override int Level => 0;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var promos = Data.GetPromos();
            string toCheck = "";
            if (message.Text.Length > 10)
            {
                toCheck = message.Text.Remove(0, 10);
            }            
            foreach (var exp in promos)
            {
                if (toCheck == exp.val && exp.expired)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "This promocode has expired!");
                    return;
                }
            }
            foreach (var promo in promos)
            {
                if (toCheck == promo.val)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Promocode activated!");
                    Pack pack;
                    pack.client = client;
                    pack.msg = message;
                    pack.dest = "";
                    Data.Load(promo.link, pack);
                    if (promo.val[0] != 'I')
                    {
                        Data.AddExpired(promo.val);
                    }
                    return;
                }
            }
            await client.SendTextMessageAsync(message.Chat.Id, "Invalid promocode!");
        }

        private void Client_OnInlineQuery(object sender, Telegram.Bot.Args.InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}