using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SourceryWeb.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract int Level { get; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(Name);
        }
        public bool PermCheck(int id)
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
    }
}