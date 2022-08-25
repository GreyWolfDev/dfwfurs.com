using DFW.Furs.Bot.Attributes;
using DFW.Furs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace DFW.Furs.Bot.Commands
{
    public static partial class Commands
    {
        [Command(Trigger = "ping", Description = "Check if online")]
        public static void Ping(Message update, string[] args)
        {
            var ts = DateTime.UtcNow - update.Date;
            var send = DateTime.UtcNow;
            var message = $"Time to receive ping message: {ts:mm\\:ss\\.ff}";
            var result = Bot.Send(message, update.Chat.Id).Result;
            ts = DateTime.UtcNow - send;
            message += "\n" + $"Time to send ping message: {ts:mm\\:ss\\.ff}";
            Bot.Client.EditMessageTextAsync(update.Chat.Id, result.MessageId, message);
        }

        [Command(Trigger = "nextevent", Description = "Get next event", ShowInCommandList = true)]
        public static void NextEvent(Message m, string[] args)
        {
            using (var db = new DFW.Furs.Database.DFWDbContext())
            {
                var next = db.Events.Include("Description").Where(x => x.TimeStamp > DateTime.Now).OrderBy(x => x.TimeStamp).First();
                var nEvent = next.Description;
                var caption = BuildCaption(nEvent);
                if (nEvent.Photo != null)
                {
                    using (var fs = new FileStream(Environment.CurrentDirectory + "/wwwroot/images/events/" + nEvent.Photo, FileMode.Open))
                    {
                        var file = new InputOnlineFile(fs);
                        var result = Bot.Client.SendPhotoAsync(m.Chat.Id, file, caption).Result;
                    }
                }
                else
                {
                    Bot.Send(caption, m.Chat.Id);
                }
            }
        }

        [Command(Trigger = "events", Description = "Get upcoming events", ShowInCommandList = true)]
        public static void Events(Message m, string[] args)
        {
            using (var db = new DFW.Furs.Database.DFWDbContext())
            {
                var nEvent = db.EventDescriptions.Include("Events").FirstOrDefault();
                var caption = BuildCaption(nEvent);

                var buttons = new[]
                {
                    new InlineKeyboardButton{CallbackData = $"events|{nEvent.Id}|prev", Text = "Previous"},
                    new InlineKeyboardButton{CallbackData = $"events|{nEvent.Id}|next", Text = "Next"}
                };

                var menu = new InlineKeyboardMarkup(buttons);


                if (nEvent.Photo != null)
                {
                    using (var fs = new FileStream(Environment.CurrentDirectory + "/wwwroot/images/events/" + nEvent.Photo, FileMode.Open))
                    {
                        var file = new InputOnlineFile(fs);
                        var result = Bot.Client.SendPhotoAsync(m.Chat.Id, file, caption, replyMarkup: menu).Result;
                    }
                }
                else
                {
                    Bot.Send(caption, m.Chat.Id, customMenu: menu);
                }
            }
        }

        internal static string BuildCaption(EventDescription nEvent)
        {
            var caption = $"{nEvent.Title}\n" +
                    $"{nEvent.Location}\n";
            if (!String.IsNullOrWhiteSpace(nEvent.Description))
                caption += $"{nEvent.Description}\n\n";

            caption += $"Fursuits: {(nEvent.FursuitFriendly ? "✅" : "❌")}\n" +
                $"Cost: {nEvent.Cost}\n" +
                $"Age: {nEvent.Age}\n" +
                $"Attendance: {nEvent.AvgAttendance}\n" +
                $"Length: {nEvent.Duration}\n" +
                $"When: {nEvent.Frequency}\n" +
                $"Tags: {nEvent.Tags}";

            var events = nEvent.Events.Where(x => x.TimeStamp.Date >= DateTime.Now.Date);
            if (events.Any())
            {
                var next = events.OrderBy(x => x.TimeStamp).First();
                caption += $"\n\nNext Event: {next.TimeStamp}";
            }

            return caption;
        }
    }
}

