using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using SourceryWeb.Models.Commands;
using System.IO;

namespace SourceryWeb.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> cmdList;
        public static IReadOnlyList<Command> Commands { get => cmdList.AsReadOnly(); }
        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            cmdList = new List<Command>
            {
                new InfoCmd(),
                new GetPromosCmd(),
                new ActivatePromoCmd(),
                new AddPromoCmd(),
                new AdminsCmd(),
                new HelpCmd(),
                new PromoteCmd(),
                new DowngradeCmd(),
                new GetIDCmd(),
                new GeneratePromosGmd()
            };
            client = new TelegramBotClient(AppSettings.Key);

            Data.InitializeComponents();
            client.OnMessage += Client_OnMessage;
            client.StartReceiving();

            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync("");
            return client;
        }

        private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var commands = Commands;
            var message = e.Message;
            try
            {
                foreach (var command in commands)
                {
                    if (command.Contains(message.Text))
                    {
                        if ((command.Level == 0) || (command.Level > 0 && command.PermCheck(message.From.Id)))
                        {
                            command.Execute(message, client);
                        }
                        else
                        {
                            client.SendTextMessageAsync(e.Message.Chat.Id, "You don't have enough permissions to execute this command");
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Data.Log(ex.Message + " " + message.Date.ToUniversalTime().ToString());
            }
        }
    }
}