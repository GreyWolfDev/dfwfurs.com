using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int EventDescriptionId { get; set; }
        public EventDescription Description { get; set; }
    }
}
