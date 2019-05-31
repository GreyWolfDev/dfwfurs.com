using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Database;
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
            return View(_context.Authentications.ToList());
        }
    }
}