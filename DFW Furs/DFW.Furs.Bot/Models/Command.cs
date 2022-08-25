using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Bot.Models
{
    class Command
    {
        public string Trigger { get; set; }
        public bool GroupAdminOnly { get; set; }
        public bool GlobalAdminOnly { get; set; }
        public bool DevOnly { get; set; }
        public bool Blockable { get; set; }
        public Bot.ChatCommandMethod Method { get; set; }
        public bool InGroupOnly { get; set; }
        public bool LangAdminOnly { get; set; }
        public string Description { get; set; }
        public bool ShowInCommandList { get; set; }
    }
}
