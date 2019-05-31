using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DFW.Furs.Models
{
    public class EventDescription
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cost { get; set; }
        public string Age { get; set; }
        public string AvgAttendance { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public string Location { get; set; }
        public virtual List<CrewMember> Organizers { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}
