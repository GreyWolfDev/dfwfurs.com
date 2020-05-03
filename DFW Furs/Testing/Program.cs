using DFW.Furs.Api;
using System;
using DFW.Furs.Database;
using Microsoft.EntityFrameworkCore;
using DFW.Furs;
using DFW.Furs.Bot;
using System.Threading;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bot.Start().Wait();
            Thread.Sleep(-1);
        }

        public static void SetupEvents()
        {
            var o = new DbContextOptionsBuilder<DFWDbContext>();
            o.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dfwfurs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //schedule some events
            using (var db = new DFWDbContext(o.Options))
            {
                //get the events
                var e = db.EventDescriptions.Find(2);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(3);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, 15);
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(4);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    if (m != 2)
                    {
                        date = new DateTime(2019, m, 29);
                        while (date.DayOfWeek != DayOfWeek.Saturday)
                            date = date.AddDays(1);

                        if (date.Month == m)
                            e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    }
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(5);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, 1);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(6);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, DateTime.DaysInMonth(2019, m));
                    while (date.DayOfWeek != DayOfWeek.Sunday)
                        date = date.AddDays(-1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }

                e = db.EventDescriptions.Find(9);
                for (var m = 1; m <= 12; m++)
                {
                    var date = new DateTime(2019, m, 8);
                    while (date.DayOfWeek != DayOfWeek.Saturday)
                        date = date.AddDays(1);

                    e.Events.Add(new DFW.Furs.Models.Event { TimeStamp = date });
                    db.SaveChanges();
                }
            }
        }
    }
}
