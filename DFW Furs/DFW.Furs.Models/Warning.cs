using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class Warning
    {
        public int Id { get; set; }
        public TgGroup OriginatingGroup { get; set; }
        public int UserId { get; set; }
        public TgUser Admin { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Reason { get; set; }
        public bool CommunityWarn { get; set; }
        public string PostLink { get; set; }
    }
}
