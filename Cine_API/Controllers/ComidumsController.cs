using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cine_API.Models;

namespace Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComidumsController : ControllerBase
    {
        private readonly CineContext _context;

        public ComidumsController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Comidums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comidum>>> GetComida()
        {
          if (_context.Comida == null)
          {
              return NotFound();
          }
            return await _context.Comida.ToListAsync();
        }

        // GET: api/Comidums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comidum>> GetComidum(int id)
        {
          if (_context.Comida == null)
          {
              return NotFound();
          }
            var comidum = await _context.Comida.FindAsync(id);

            if (comidum == null)
            {
                return NotFound();
            }

            return comidum;
        }

        // PUT: api/Comidums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComidum(int id, Comidum comidum)
        {
            if (id != comidum.IdComida)
            {
                return BadRequest();
            }

            _context.Entry(comidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComidumExists(id))
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

        // POST: api/Comidums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comidum>> PostComidum(Comidum comidum)
        {
          if (_context.Comida == null)
          {
              return Problem("Entity set 'CineContext.Comida'  is null.");
          }
            _context.Comida.Add(comidum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComidumExists(comidum.IdComida))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComidum", new { id = comidum.IdComida }, comidum);
        }

        // DELETE: api/Comidums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComidum(int id)
        {
            if (_context.Comida == null)
            {
                return NotFound();
            }
            var comidum = await _context.Comida.FindAsync(id);
            if (comidum == null)
            {
                return NotFound();
            }

            _context.Comida.Remove(comidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComidumExists(int id)
        {
            return (_context.Comida?.Any(e => e.IdComida == id)).GetValueOrDefault();
        }
    }
}
