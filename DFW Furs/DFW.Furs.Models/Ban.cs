using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class Ban
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TgUser Admin { get; set; }
        public string Reason { get; set; }
        public TgGroup Group { get; set; }
        public bool CommunityBan { get; set; }
        public string PostLink { get; set; }
    }
}
