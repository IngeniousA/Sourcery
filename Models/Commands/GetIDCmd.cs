using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class GetIDCmd : Command
    {
        public override string Name => "/id";

        public override int Level => 0;

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string res = "Your ID is " + message.From.Id;
            await client.SendTextMessageAsync(message.Chat.Id, res);
        }
    }
}