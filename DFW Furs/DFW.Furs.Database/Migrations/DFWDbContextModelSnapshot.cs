﻿// <auto-generated />
using System;
using DFW.Furs.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DFW.Furs.Database.Migrations
{
    [DbContext(typeof(DFWDbContext))]
    partial class DFWDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DFW.Furs.Models.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About");

                    b.Property<string>("Name");

                    b.Property<string>("Photo64");

                    b.Property<int>("Roles");

                    b.Property<int>("TelegramId");

                    b.Property<int?>("TelegramUserId");

                    b.HasKey("Id");

                    b.HasIndex("TelegramUserId");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("DFW.Furs.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventDescriptionId");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("EventDescriptionId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DFW.Furs.Models.EventDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Age");

                    b.Property<string>("AvgAttendance");

                    b.Property<string>("ChatLink");

                    b.Property<string>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Duration");

                    b.Property<string>("Frequency");

                    b.Property<bool>("FursuitFriendly");

                    b.Property<string>("Location");

                    b.Property<bool>("NoMinors");

                    b.Property<string>("Photo");

                    b.Property<bool>("RSVPRequired");

                    b.Property<string>("Tags");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EventDescriptions");
                });

            modelBuilder.Entity("DFW.Furs.Models.EventOrganizer", b =>
                {
                    b.Property<int>("CrewMemberId");

                    b.Property<int>("EventDescriptionId");

                    b.HasKey("CrewMemberId", "EventDescriptionId");

                    b.HasIndex("EventDescriptionId");

                    b.ToTable("EventOrganizer");
                });

            modelBuilder.Entity("DFW.Furs.Models.TgGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminUserName");

                    b.Property<bool>("AllowNSFW");

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<bool>("EnableCaptcha");

                    b.Property<bool>("EnableCommunityBans");

                    b.Property<string>("Link");

                    b.Property<int>("MemberCount");

                    b.Property<int>("NSFWAction");

                    b.Property<string>("Name");

                    b.Property<long>("TelegramId");

                    b.Property<string>("WelcomeMessage");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DFW.Furs.Models.TgUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AgeVerified");

                    b.Property<string>("Name");

                    b.Property<int>("Points");

                    b.Property<int>("TelegramId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("TgUser");
                });

            modelBuilder.Entity("DFW.Furs.Models.TgUserAuth", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("auth_date");

                    b.Property<string>("first_name");

                    b.Property<string>("hash");

                    b.Property<string>("last_name");

                    b.Property<string>("photo_url");

                    b.Property<int>("telegram_id");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("Authentications");
                });

            modelBuilder.Entity("DFW.Furs.Models.CrewMember", b =>
                {
                    b.HasOne("DFW.Furs.Models.TgUser", "TelegramUser")
                        .WithMany()
                        .HasForeignKey("TelegramUserId");
                });

            modelBuilder.Entity("DFW.Furs.Models.Event", b =>
                {
                    b.HasOne("DFW.Furs.Models.EventDescription", "Description")
                        .WithMany("Events")
                        .HasForeignKey("EventDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DFW.Furs.Models.EventOrganizer", b =>
                {
                    b.HasOne("DFW.Furs.Models.CrewMember", "CrewMember")
                        .WithMany("OrganizedEvents")
                        .HasForeignKey("CrewMemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DFW.Furs.Models.EventDescription", "EventDescription")
                        .WithMany("Organizers")
                        .HasForeignKey("EventDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
