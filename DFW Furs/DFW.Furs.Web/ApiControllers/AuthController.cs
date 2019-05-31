using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DFW.Furs.Database;
using DFW.Furs.Models;

namespace DFW.Furs.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DFWDbContext _context;

        public AuthController(DFWDbContext context)
        {
            _context = context;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TgUserAuth>>> GetAuthentications()
        {
            return await _context.Authentications.ToListAsync();
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TgUserAuth>> GetTgUserAuth(int id)
        {
            var tgUserAuth = await _context.Authentications.FindAsync(id);

            if (tgUserAuth == null)
            {
                return NotFound();
            }

            return tgUserAuth;
        }

        // PUT: api/Auth/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTgUserAuth(int id, TgUserAuth tgUserAuth)
        {
            if (id != tgUserAuth.id)
            {
                return BadRequest();
            }

            _context.Entry(tgUserAuth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TgUserAuthExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Auth
        [HttpPost]
        public async Task<ActionResult<TgUserAuth>> PostTgUserAuth([FromBody] TgUserAuth tgUserAuth)
        {
            tgUserAuth.telegram_id = tgUserAuth.id;
            tgUserAuth.id = 0;
            _context.Authentications.Add(tgUserAuth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTgUserAuth", new { id = tgUserAuth.id }, tgUserAuth);
        }

        // DELETE: api/Auth/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TgUserAuth>> DeleteTgUserAuth(int id)
        {
            var tgUserAuth = await _context.Authentications.FindAsync(id);
            if (tgUserAuth == null)
            {
                return NotFound();
            }

            _context.Authentications.Remove(tgUserAuth);
            await _context.SaveChangesAsync();

            return tgUserAuth;
        }

        private bool TgUserAuthExists(int id)
        {
            return _context.Authentications.Any(e => e.id == id);
        }
    }
}
