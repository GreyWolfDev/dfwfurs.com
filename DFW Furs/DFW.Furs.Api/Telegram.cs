using DFW.Furs.Api.Interfaces;
using DFW.Furs.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DFW.Furs.Api
{
    public class Telegram : ISocialMedia<TgChannelPost>
    {
        private static HttpClient _client = new HttpClient();
        /// <summary>
        /// Gets the posts from a public Telegram channel
        /// </summary>
        /// <param name="channel">The username of the channel</param>
        /// <param name="count">How many posts to return</param>
        /// <param name="before">The ID of the post you want messages before</param>
        /// <param name="after">The ID of the post you want messages after</param>
        /// <returns>A list of TgChannelPost objects</returns>
        public static async Task<List<TgChannelPost>> ParseChannel(string channel, int count = 5, int before = 0, int after = 0)
        {
            var url = $"https://t.me/s/{channel}";
            if (before != 0)
            {
                url += $"?before={before}";
            }
            else if (after != 0)
            {
                url += $"?after={after}";
            }
            var r = await _client.GetAsync(url);
            var c = await r.Content.ReadAsStringAsync();
            if (r.RequestMessage.RequestUri.AbsoluteUri == $"https://t.me/{channel}")
            {
                //channel isn't supported, or is not a channel.  If a valid channel, probably blocked (NSFW)
                throw new NotSupportedException("Channel is either blocked or is not a valid channel");
            }
            var doc = new HtmlDocument();
            doc.LoadHtml(c);
            var rawPosts = doc.DocumentNode.SelectNodes("//div[contains(@class, 'tgme_widget_message_wrap')]");
            var result = new List<TgChannelPost>();
            foreach (var p in rawPosts)
            {
                var post = new TgChannelPost();
                var postNode = new HtmlDocument();
                post.RawHtml = p.InnerHtml;
                postNode.LoadHtml(p.InnerHtml);
                var d = postNode.DocumentNode;
                var t = d.FirstChild;
                var postId = t.Attributes["data-post"].Value;
                postId = postId.Substring(postId.IndexOf("/") + 1);
                post.Id = int.Parse(postId);

                t = t.ChildNodes[1].ChildNodes.FindFirst("img");
                post.AuthorImage = t.Attributes["src"].Value;
                var msg = d.SelectSingleNode("//div[contains(@class, 'tgme_widget_message_bubble')]");
                t = msg.SelectSingleNode("//a[contains(@class, 'tgme_widget_message_owner_name')]").FirstChild;
                post.MessageAuthor = t.InnerText;
                t = msg.SelectSingleNode("//a[contains(@class, 'tgme_widget_message_forwarded_from_name')]");
                if (t != null)
                {
                    post.ForwardedFromLink = t.Attributes["href"].Value;
                    post.ForwardedFromName = t.InnerHtml;
                }

                //TODO: Guess what, you forgot to handle albums. *slapslap*.  Probably stickers and voice too!
                t = msg.SelectSingleNode("//a[contains(@class, 'tgme_widget_message_photo_wrap')]");
                if (t != null)
                {
                    var style = t.Attributes["style"].Value;
                    var src = new Regex(@"(?<=(url\(')).*(?=('\)))").Match(style).Value;
                    post.PostImage = src;
                }
                t = msg.SelectSingleNode("//a[contains(@class, 'tgme_widget_message_video_player')]");
                if (t != null)
                {
                    var style = t.ChildNodes.FindFirst("i").Attributes["style"].Value;
                    var src = new Regex(@"(?<=(url\(')).*(?=('\)))").Match(style).Value;
                    post.VideoThumbnail = src;
                    t = t.ChildNodes.FindFirst("video");
                    post.VideoUrl = t.Attributes["src"].Value;
                }
                t = msg.SelectSingleNode("//div[contains(@class, 'tgme_widget_message_text')]");
                if (t != null)
                    post.Text = t.InnerHtml;
                t = msg.SelectSingleNode("//div[contains(@class, 'tgme_widget_message_info')]");
                post.ViewCount = t.ChildNodes.FindFirst("span").InnerText;
                t = msg.SelectSingleNode("//a[contains(@class, 'tgme_widget_message_date')]").ChildNodes.FindFirst("time");
                post.Timestamp = DateTime.Parse(t.Attributes["datetime"].Value);
                result.Add(post);
            }
            return result.OrderByDescending(x => x.Timestamp).Take(count).ToList();
        }

        public async Task<IEnumerable<TgChannelPost>> GetItems(string identifier, int count) => await ParseChannel(identifier, count);
    }
}
