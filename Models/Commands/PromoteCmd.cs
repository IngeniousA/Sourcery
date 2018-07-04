using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class PromoteCmd : Command
    {
        public override string Name => "/promote";

        public override int Level => 1;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            if (message.Text.Length < 11)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Invalid parameter!");
                return;
            }
            string id = message.Text.Substring(9, message.Text.Length - 9);
            if (Data.GetOP().Contains(id))
            {
                await client.SendTextMessageAsync(message.Chat.Id, "User " + id + " already promoted!");
                return;
            }
            Data.AddOP(id);
            await client.SendTextMessageAsync(message.Chat.Id, "User " + id + " promoted!");
        }
    }
}