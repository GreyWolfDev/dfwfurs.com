using Microsoft.AspNetCore.Identity;
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
        None = 0,
        Admin = 1,
        Developer = 2,
        EventOrganizer = 4,
        BlogWriter = 8,
        CrewMember = 16
    }
    public static class Extension
    {
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }
    }
}
