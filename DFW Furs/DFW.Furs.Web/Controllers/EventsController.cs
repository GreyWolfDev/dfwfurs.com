using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var events = _context.Events.Include("Description").Where(x => x.TimeStamp >= DateTime.Now.AddDays(-1)).OrderBy(x => x.TimeStamp).Take(20);
            return View(events);
        }

        public IActionResult Descriptions()
        {
            var events = _context.EventDescriptions.Where(x => x.Active).OrderBy(x => x.Title).ToList();
            var tags = events.Where(x => x.Tags != null).SelectMany(x => x.Tags.Split(",")).Select(x => x.Trim()).Distinct();
            ViewData["tags"] = tags;
            return View(events);
        }

        public async Task<IActionResult> Description(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDescription = await _context.EventDescriptions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventDescription == null)
            {
                return NotFound();
            }

            return View(eventDescription);
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