using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Bot.Models;
using DFW.Furs.Database;
using Microsoft.Win32;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DFW.Furs.Bot
{
    public static class Bot
    {
        public static Telegram.Bot.ITelegramBotClient Client;
        internal static List<Command> Commands = new List<Command>();
        internal delegate void ChatCommandMethod(Message u, string[] args);
        internal static DFWDbContext _context;
        public static User Me;
        public static async Task Start(string token)
        {
            Client = new Telegram.Bot.TelegramBotClient(token);
            //_context = new DFWDbContext()
            //load the commands list
            foreach (var m in typeof(Commands.Commands).GetMethods())
            {
                var c = new Command();
                foreach (var a in m.GetCustomAttributes(true))
                {
                    if (a is Attributes.Command)
                    {
                        var ca = a as Attributes.Command;
                        c.Blockable = ca.Blockable;
                        c.DevOnly = ca.DevOnly;
                        c.GlobalAdminOnly = ca.GlobalAdminOnly;
                        c.GroupAdminOnly = ca.GroupAdminOnly;
                        c.Trigger = ca.Trigger;
                        c.Method = (ChatCommandMethod)Delegate.CreateDelegate(typeof(ChatCommandMethod), m);
                        c.InGroupOnly = ca.InGroupOnly;
                        c.LangAdminOnly = ca.LangAdminOnly;
                        c.Description = ca.Description;
                        c.ShowInCommandList = ca.ShowInCommandList;
                        Commands.Add(c);
                    }
                }
            }

            Me = await Client.GetMeAsync();
            var botCommands = Commands.Where(x => x.ShowInCommandList).Select(x => new BotCommand { Command = x.Trigger, Description = x.Description }).ToList();
            await Client.SetMyCommandsAsync(botCommands);
            Client.OnMessage += Client_OnMessage;
            Client.OnCallbackQuery += Client_OnCallbackQuery;
            Client.OnInlineQuery += Client_OnInlineQuery;
            Client.OnUpdate += Client_OnUpdate;
            Client.OnReceiveError += Client_OnReceiveError;
            Client.OnReceiveGeneralError += Client_OnReceiveGeneralError;
            Client.StartReceiving();
#if RELEASE
            try
            {
                if (Environment.MachineName != "DESKTOP-O26AQPR")
                    await Client.SendTextMessageAsync(-226056121, "Update completed");
            }
            catch
            {
                //ignore
            }
#endif



            //new[] { UpdateType.Message, UpdateType.InlineQuery, UpdateType.Poll, UpdateType.EditedMessage, UpdateType.EditedChannelPost, UpdateType.ChosenInlineResult, UpdateType.ChannelPost, UpdateType.CallbackQuery }

        }

        private static void Client_OnReceiveGeneralError(object sender, Telegram.Bot.Args.ReceiveGeneralErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void Client_OnReceiveError(object sender, Telegram.Bot.Args.ReceiveErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void Client_OnUpdate(object sender, Telegram.Bot.Args.UpdateEventArgs e)
        {
            //if (e.Update.Message != null)
            //    new Task(() => HandleUpdate(e.Update.Message)).Start();
        }

        private static void Client_OnInlineQuery(object sender, Telegram.Bot.Args.InlineQueryEventArgs e)
        {

        }

        private static void Client_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            //TODO: use reflection to build callback commands
            var args = e.CallbackQuery.Data.Split('|');
            switch (args[0])
            {
                case "events":
                    Helpers.SwitchEvent(e.CallbackQuery);
                    break;
            }
        }

        private static void Client_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            new Task(() => HandleUpdate(e.Message)).Start();
        }

        private static void HandleUpdate(Message m)
        {
            if (!String.IsNullOrWhiteSpace(m.Text))
            {
                if (m.Text.StartsWith("!") || m.Text.StartsWith("/"))
                {
                    var args = GetParameters(m.Text);
                    args[0] = args[0].ToLower().Replace("@" + Me.Username.ToLower(), "");


                    var command = Commands.FirstOrDefault(x =>
                                            String.Equals(x.Trigger, args[0],
                                                StringComparison.InvariantCultureIgnoreCase));

                    if (command != null)
                    {
                        command.Method.Invoke(m, args);
                    }
                }
            }
            switch (m.Type)
            {
                case MessageType.Unknown:
                    break;
                case MessageType.Text:
                    break;
                case MessageType.Photo:
                    break;
                case MessageType.Audio:
                    break;
                case MessageType.Video:
                    break;
                case MessageType.Voice:
                    break;
                case MessageType.Document:
                    break;
                case MessageType.Sticker:
                    break;
                case MessageType.Location:
                    break;
                case MessageType.Contact:
                    break;
                case MessageType.Venue:
                    break;
                case MessageType.Game:
                    break;
                case MessageType.VideoNote:
                    break;
                case MessageType.Invoice:
                    break;
                case MessageType.SuccessfulPayment:
                    break;
                case MessageType.WebsiteConnected:
                    break;
                case MessageType.ChatMembersAdded:
                    break;
                case MessageType.ChatMemberLeft:
                    break;
                case MessageType.ChatTitleChanged:
                    break;
                case MessageType.ChatPhotoChanged:
                    break;
                case MessageType.MessagePinned:
                    break;
                case MessageType.ChatPhotoDeleted:
                    break;
                case MessageType.GroupCreated:
                    break;
                case MessageType.SupergroupCreated:
                    break;
                case MessageType.ChannelCreated:
                    break;
                case MessageType.MigratedToSupergroup:
                    break;
                case MessageType.MigratedFromGroup:
                    break;
                case MessageType.Animation:
                    break;
                case MessageType.Poll:
                    break;
                case MessageType.Dice:
                    break;
            }
        }

        internal static Task<Message> Send(string message, long id, bool clearKeyboard = false, InlineKeyboardMarkup customMenu = null, ParseMode parseMode = ParseMode.Html)
        {

            //message = message.Replace("`",@"\`");
            if (clearKeyboard)
            {
                //var menu = new ReplyKeyboardRemove() { RemoveKeyboard = true };
                return Client.SendTextMessageAsync(id, message, replyMarkup: customMenu, disableWebPagePreview: true, parseMode: parseMode);
            }
            else if (customMenu != null)
            {
                return Client.SendTextMessageAsync(id, message, replyMarkup: customMenu, disableWebPagePreview: true, parseMode: parseMode);
            }
            else
            {
                return Client.SendTextMessageAsync(id, message, disableWebPagePreview: true, parseMode: parseMode);
            }

        }

        private static string[] GetParameters(string input)
        {
            return input.Contains(" ") ? new[] { input.Substring(1, input.IndexOf(" ")).Trim(), input.Substring(input.IndexOf(" ") + 1) } : new[] { input.Substring(1).Trim(), null };
        }
    }
}
