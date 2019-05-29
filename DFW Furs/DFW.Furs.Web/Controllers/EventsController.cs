using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult Descriptions()
        {
            return View();
        }
        public IActionResult Organizers()
        {
            return View();
        }
        public IActionResult Photos()
        {
            return View();
        }
    }
}