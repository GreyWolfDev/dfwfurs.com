using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Database;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.Controllers
{
    
    public class EventsController : Controller
    {
        private readonly DFWDbContext _context;

        public EventsController(DFWDbContext context)
        {
            _context = context;
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Descriptions()
        {
            var events = _context.EventDescriptions.ToList();
            var tags = events.Where(x => x.Tags != null).SelectMany(x => x.Tags.Split(",")).Select(x => x.Trim()).Distinct();
            ViewData["tags"] = tags;
            return View(_context.EventDescriptions.ToList());
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