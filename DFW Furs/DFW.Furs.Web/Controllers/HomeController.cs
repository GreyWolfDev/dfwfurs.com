using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DFW.Furs.Web.Models;
using DFW.Furs.Database;
using Microsoft.EntityFrameworkCore;

namespace DFW.Furs.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DFWDbContext _context;

        public HomeController(DFWDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var today = DateTime.Now.Date;
            return View(_context.Events.Include("Description").Where(x => x.TimeStamp.Date >= today).OrderBy(x => x.TimeStamp).Take(5).ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Connect()
        {
            return View();
        }
    }
}
