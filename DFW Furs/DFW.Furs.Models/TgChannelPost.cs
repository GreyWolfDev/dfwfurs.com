using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class TgChannelPost : IPost
    {
        public string AuthorImage { get; set; }
        public string MessageAuthor { get; set; } //should be the channels name
        public string ForwardedFromName { get; set; }
        public string ForwardedFromLink { get; set; }
        public string Text { get; set; }
        public string ViewCount { get; set; }
        public string PostImage { get; set; }
        public DateTime Timestamp { get; set; }
        public string VideoUrl { get; set; }
        public string VideoThumbnail { get; set; }
    }
}
