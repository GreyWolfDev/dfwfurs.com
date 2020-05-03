using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DFW.Furs.Models;
using Microsoft.Win32;

namespace DFW.Furs.Database
{
    public class DFWDbContext : DbContext
    {
        public DFWDbContext(DbContextOptions<DFWDbContext> options)
            : base(options)
        {

        }

        public DFWDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConnectionString);



        public static string ConnectionString { get; set; }


        public DbSet<CrewMember> CrewMembers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDescription> EventDescriptions { get; set; }
        public DbSet<TgUserAuth> Authentications { get; set; }
        public virtual DbSet<TgGroup> Groups { get;set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventOrganizer>()
                .HasKey(t => new { t.CrewMemberId, t.EventDescriptionId });

            modelBuilder.Entity<EventOrganizer>()
                .HasOne(x => x.CrewMember)
                .WithMany(x => x.OrganizedEvents)
                .HasForeignKey(x => x.CrewMemberId);

            modelBuilder.Entity<EventOrganizer>()
                .HasOne(x => x.EventDescription)
                .WithMany(x => x.Organizers)
                .HasForeignKey(x => x.EventDescriptionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
