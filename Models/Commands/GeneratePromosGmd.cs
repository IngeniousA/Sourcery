using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class GeneratePromosGmd : Command
    {
        public override string Name => "/generate"; // /generate <link> <amount> <C/D/I>

        public override int Level => 1;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string address = "", amount = "";
            int num = 0;
            if (message.Text.Length < 11)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            string raw = message.Text.Substring(10, message.Text.Length - 10);
            char ch = raw[0];
            int it = 0;
            try
            {
                while (ch != ' ')
                {
                    ch = raw[it];
                    if (ch != ' ')
                    {
                        address += raw[it];
                        it++;
                    }
                }
                while (it != raw.Length - 2)
                {
                    amount += raw[it];
                    it++;
                }
                num = Convert.ToInt32(amount);
            }
            catch (Exception)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            if (num < 1)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            string output = "";
            switch (raw[raw.Length - 1].ToString().ToLower())
            {
                case "c":
                    for (int i = 0; i < num; i++)
                    {
                        Promo pr = new Promo(address, Promo.PromoType.Continuous);
                        Data.AddPromo(pr.val + pr.link);
                        output += pr.val + "\n";
                    }
                    break;
                case "d":
                    for (int i = 0; i < num; i++)
                    {
                        Promo pr = new Promo(address, Promo.PromoType.Dashed);
                        Data.AddPromo(pr.val + pr.link);
                        output += pr.val + "\n";
                    }
                    break;
                case "i":
                    for (int i = 0; i < num; i++)
                    {
                        Promo pr = new Promo(address, Promo.PromoType.Infinite);
                        Data.AddPromo(pr.val + pr.link);
                        output += pr.val + "\n";
                    }
                    break;
                default:
                    await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                    return;
            }
            await client.SendTextMessageAsync(message.Chat.Id, "Added promocodes:\n" + output);
        }
    }
}