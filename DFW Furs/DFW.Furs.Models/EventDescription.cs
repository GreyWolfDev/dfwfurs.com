using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DFW.Furs.Models
{
    public class EventDescription
    {
        public EventDescription()
        {
            Organizers = new List<EventOrganizer>();
            Events = new List<Event>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string Age { get; set; }
        public string AvgAttendance { get; set; }
        public string Duration { get; set; }
        public string Frequency { get; set; }
        public string Location { get; set; }
        public string Photo { get; set; }
        public string Tags { get; set; }
        public bool FursuitFriendly { get; set; }
        
        public virtual ICollection<EventOrganizer> Organizers { get; set; }
        [InverseProperty("Description")]

        public ICollection<Event> Events { get; set; }
    }
}
