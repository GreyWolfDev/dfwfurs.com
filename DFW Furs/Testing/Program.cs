using DFW.Furs.Api;
using System;
using DFW.Furs.Database;
using Microsoft.EntityFrameworkCore;
using DFW.Furs;
using DFW.Furs.Bot;
using System.Threading;
using DFW.Furs.Models;
using System.Collections.Generic;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bot.Start().Wait();
            //CopyData();
            SetupEvents();
            Console.ReadLine();
        }

        static void CopyData()
        {
            //var source = new DbContextOptionsBuilder<DFWDbContext>();
            //source.UseSqlServer(@"Data Source=localhost\\GREYWOLF;Initial Catalog=dfwfurs;User Id=dfwfurs;Password=no;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //var dest = new DbContextOptionsBuilder<DFWDbContext>();
            //dest.UseSqlServer(@"Data Source=88.198.179.81;Initial Catalog=dfwfurs;User Id=dfwfurs;Password=no;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            List<TgGroup> Groups;
            List<EventDescription> Descriptions;
            using (var sourceDB = new DFWDbContext(@"Data Source=localhost\GREYWOLF;Initial Catalog=dfwfurs;User Id=dfwfurs;Password=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                Console.WriteLine("Testing connection to source");
                var test = sourceDB.EventDescriptions.FirstOrDefaultAsync().Result;
                Console.WriteLine(test.Title);
                Descriptions = sourceDB.EventDescriptions.ToListAsync().Result;
                Groups = sourceDB.Groups.ToListAsync().Result;
                //get all events
            }



            using (var destDB = new DFWDbContext(@"Data Source=88.198.179.81;Initial Catalog=dfwfurs;User Id=dfwfurs;Password=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                using (var transaction = destDB.Database.BeginTransaction())
                {

                    Console.WriteLine("Testing connection to destination");
                    //var test = destDB.EventDescriptions.FirstOrDefaultAsync().Result;
                    //Console.WriteLine(test.Title);
                    Console.WriteLine("Clearing Groups");
                    //destDB.RemoveRange(destDB.Groups);
                    ////destDB.RemoveRange(destDB.EventDescriptions);
                    //destDB.SaveChanges();
                    //Console.WriteLine("Adding new data");
                    //destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Groups] ON");
                    ////destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[EventDescriptions] ON");
                    //destDB.Groups.AddRange(Groups);
                    ////destDB.EventDescriptions.AddRange(Descriptions);
                    //destDB.SaveChanges();
                    //destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Groups] OFF");
                    //transaction.Commit();

                    Console.WriteLine("Clearing descriptions");
                    //destDB.RemoveRange(destDB.Groups);
                    destDB.RemoveRange(destDB.EventDescriptions);
                    destDB.SaveChanges();
                    Console.WriteLine("Adding new data");
                    destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[EventDescriptions] ON");
                    //destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[EventDescriptions] ON");
                    //destDB.Groups.AddRange(Groups);
                    destDB.EventDescriptions.AddRange(Descriptions);
                    destDB.SaveChanges();
                    destDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[EventDescriptions] OFF");
                    transaction.Commit();

                }
            }
            Console.WriteLine("Done");
        }

        public static void SetupEvents()
        {
            var o = new DbContextOptionsBuilder<DFWDbContext>();
            o.UseSqlServer(@"Data Source=localhost;Initial Catalog=dfwfurs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //schedule some events
            using (var db = new DFWDbContext(@"Data Source=88.198.179.81;Initial Catalog=dfwfurs;User Id=dfwfurs;Password=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                //get the events
                var e = db.EventDescriptions.Find(1);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }
                e = db.EventDescriptions.Find(2);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, 8);
                    //second sunday
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(3);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, 15);
                    //third sunday
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(4);
                for (var m = 1; m <= 12; m++)
                {

                    var date = new DateTime(2022, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    
                    if (date.Month == m)
                        e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });

                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(5);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, 1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(6);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, DateTime.DaysInMonth(2022, m));
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(-1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(9);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2022, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);
                    date = date.AddDays(1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                Console.WriteLine("Done");
            }
        }
    }
}
