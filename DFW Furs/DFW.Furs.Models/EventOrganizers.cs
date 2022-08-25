using System;
using System.Collections.Generic;
using System.Text;

namespace DFW.Furs.Models
{
    public class EventOrganizer
    {
        public int EventDescriptionId { get; set; }
        public EventDescription EventDescription { get; set; }

        public int CrewMemberId { get; set; }
        public CrewMember CrewMember { get; set; }
    }
}
