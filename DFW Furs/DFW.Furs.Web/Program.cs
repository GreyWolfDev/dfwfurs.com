using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DFW.Furs.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",
                     optional: false,
                     reloadOnChange: true)
                .AddJsonFile("secrets.json",
                    optional: false,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            return WebHost.CreateDefaultBuilder(args).UseConfiguration(config).UseStartup<Startup>();
        }
    }
}
