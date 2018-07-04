using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class DowngradeCmd : Command
    {
        public override string Name => "/downgrade";

        public override int Level => 1;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (message.Text.Length < 11)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            string id = message.Text.Substring(11, message.Text.Length - 11);
            if (!Data.GetOP().Contains(id))
            {
                await client.SendTextMessageAsync(message.Chat.Id, "User " + id + " wasn\'t promoted!");
                return;
            }
            Data.RemoveOP(id);
            await client.SendTextMessageAsync(message.Chat.Id, "User " + id + " downgraded!");
        }
    }
}