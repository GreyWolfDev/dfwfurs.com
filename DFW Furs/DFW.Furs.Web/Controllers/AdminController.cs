using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Database;
using DFW.Furs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DFW.Furs.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly DFWDbContext _context;

        public AdminController(DFWDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<TgUserAuth> response = new List<TgUserAuth>();
            if (HttpContext.Session.GetInt32("TelegramId") != null)
            {
                return View(_context.Authentications.ToList());
            }
            return RedirectToAction("Profile");
        }

        public IActionResult Profile()
        {
            var id = HttpContext.Session.GetInt32("TelegramId");
            if (id != null)
            {
                return View(_context.CrewMembers.FirstOrDefault(x => x.Id == id));
            }
            return View();
        }
    }
}