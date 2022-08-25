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

namespace DFW.Furs.Bot
{
    public static class Helpers
    {
        public static void SwitchEvent(CallbackQuery query)
        {
            using (var db = new DFW.Furs.Database.DFWDbContext())
            {
                var args = query.Data.Split('|');
                var id = int.Parse(args[1]);

                var ids = db.EventDescriptions.Select(x => x.Id);
                EventDescription nEvent = null;
                while (nEvent == null)
                {
                    if (args[2] == "next")
                    {
                        id++;
                        if (db.EventDescriptions.All(x => x.Id < id))
                            id = 1;
                    }
                    else
                    {
                        id--;
                        if (db.EventDescriptions.All(x => x.Id > id))
                            id = db.EventDescriptions.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                        
                    }

                   

                    nEvent = db.EventDescriptions.Include("Events").FirstOrDefault(x => x.Id == id);
                }
                var caption = Commands.Commands.BuildCaption(nEvent);

                var buttons = new[]
                {
                    new InlineKeyboardButton{CallbackData = $"events|{nEvent.Id}|prev", Text = "Previous"},
                    new InlineKeyboardButton{CallbackData = $"events|{nEvent.Id}|next", Text = "Next"}
                };

                var menu = new InlineKeyboardMarkup(buttons);

                Bot.Client.DeleteMessageAsync(query.Message.Chat.Id, query.Message.MessageId);
                if (nEvent.Photo != null)
                {
                    using (var fs = new FileStream(Environment.CurrentDirectory + "/wwwroot/images/events/" + nEvent.Photo, FileMode.Open))
                    {
                        var file = new InputOnlineFile(fs);
                        var result = Bot.Client.SendPhotoAsync(query.Message.Chat.Id, file, caption, replyMarkup: menu, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html).Result;
                    }
                }
                else
                {
                    Bot.Send(caption, query.Message.Chat.Id, customMenu: menu, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
                }
            }
        }
    }
}
