using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public class InfoCmd : Command
    { 
        public override string Name => "/info";
        public override int Level => 0;
        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatID = message.Chat.Id;
            await client.SendTextMessageAsync(chatID, "Sourcery\nBot for sharing precious information.\nMade by Ingenious, 2018."); 
        }
    }
}