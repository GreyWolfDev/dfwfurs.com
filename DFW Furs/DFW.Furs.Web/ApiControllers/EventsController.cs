using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DFW.Furs.Database;
using DFW.Furs.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EventsController : ControllerBase
    {
        private readonly DFWDbContext _context;

        public EventsController(DFWDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Event> GetEvents(int limit = 5)
        {
            var today = DateTime.Now.Date;

            return _context.Events.Include("Description").Where(x => x.TimeStamp.Date >= today).OrderBy(x => x.TimeStamp).Take(limit).ToList();
        }
    }
}