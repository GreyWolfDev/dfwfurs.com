using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DFW.Furs.Web.Models;


namespace DFW.Furs.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Response.Cookies.Append("telegram-login", "89725a909fba421b3c991da11f5077010841eb8128eb2fa35674f51b9f5805ca");
            return View();

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
