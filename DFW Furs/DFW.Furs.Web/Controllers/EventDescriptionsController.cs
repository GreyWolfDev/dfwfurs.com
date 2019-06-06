using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DFW.Furs.Database;
using DFW.Furs.Models;
using DFW.Furs.Web.Security;

namespace DFW.Furs.Web.Controllers
{
    [Secure(Role.EventOrganizer)]
    public class EventDescriptionsController : Controller
    {
        private readonly DFWDbContext _context;

        public EventDescriptionsController(DFWDbContext context)
        {
            _context = context;
        }

        // GET: EventDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventDescriptions.ToListAsync());
        }

        // GET: EventDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: EventDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Cost,Age,AvgAttendance,Duration,Frequency,Location,Photo,Tags,FursuitFriendly")] EventDescription eventDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventDescription);
        }

        // GET: EventDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventDescription = await _context.EventDescriptions.FindAsync(id);
            if (eventDescription == null)
            {
                return NotFound();
            }
            return View(eventDescription);
        }

        // POST: EventDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Cost,Age,AvgAttendance,Duration,Frequency,Location,Photo,Tags,FursuitFriendly")] EventDescription eventDescription)
        {
            if (id != eventDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventDescriptionExists(eventDescription.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventDescription);
        }

        // GET: EventDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: EventDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDescription = await _context.EventDescriptions.FindAsync(id);
            _context.EventDescriptions.Remove(eventDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventDescriptionExists(int id)
        {
            return _context.EventDescriptions.Any(e => e.Id == id);
        }
    }
}
