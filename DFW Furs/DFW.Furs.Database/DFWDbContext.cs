using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DFW.Furs.Models;

namespace DFW.Furs.Database
{
    public class DFWDbContext : DbContext
    {
        public DFWDbContext (DbContextOptions<DFWDbContext> options)
            : base(options)
        {

        }

        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDescription> EventDescriptions { get; set; }

    }
}
