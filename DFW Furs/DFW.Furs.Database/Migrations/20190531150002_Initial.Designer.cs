﻿// <auto-generated />
using System;
using DFW.Furs.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DFW.Furs.Database.Migrations
{
    [DbContext(typeof(DFWDbContext))]
    [Migration("20190531150002_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DFW.Furs.Models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventDescriptionId");

                    b.Property<string>("Name");

                    b.Property<int>("TelegramId");

                    b.HasKey("Id");

                    b.HasIndex("EventDescriptionId");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("DFW.Furs.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DescriptionId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DFW.Furs.Models.EventDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age");

                    b.Property<string>("AvgAttendance");

                    b.Property<string>("Cost");

                    b.Property<string>("Duration");

                    b.Property<string>("Frequency");

                    b.Property<string>("Location");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EventDescriptions");
                });

            modelBuilder.Entity("DFW.Furs.Models.CrewMember", b =>
                {
                    b.HasOne("DFW.Furs.Models.EventDescription")
                        .WithMany("Organizers")
                        .HasForeignKey("EventDescriptionId");
                });

            modelBuilder.Entity("DFW.Furs.Models.Event", b =>
                {
                    b.HasOne("DFW.Furs.Models.EventDescription", "Description")
                        .WithMany("Events")
                        .HasForeignKey("DescriptionId");
                });
#pragma warning restore 612, 618
        }
    }
}
