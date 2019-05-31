using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DFW.Furs.Models
{
    public class CrewMember
    {
        public CrewMember()
        {
            OrganizedEvents = new List<EventOrganizer>();
        }
        public int Id { get; set; }
        public int TelegramId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        /// <summary>
        /// Base64 Image
        /// </summary>
        public string Photo64 { get; set; }
        public Role Roles { get; set; }
        
        public virtual ICollection<EventOrganizer> OrganizedEvents { get; set; }
    }

    [Flags]
    public enum Role
    {
        Admin,
        Developer,
        EventOrganizer,
        BlogWriter
    }
}
