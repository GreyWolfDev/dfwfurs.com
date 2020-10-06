using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class TgUser
    {
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Points { get; set; }
        public bool AgeVerified { get; set; }
    }
}
