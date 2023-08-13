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
    public class SalaCinesController : ControllerBase
    {
        private readonly CineContext _context;

        public SalaCinesController(CineContext context)
        {
            _context = context;
        }

        // GET: api/SalaCines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaCine>>> GetSalaCines()
        {
          if (_context.SalaCines == null)
          {
              return NotFound();
          }
            return await _context.SalaCines.ToListAsync();
        }

        // GET: api/SalaCines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaCine>> GetSalaCine(int id)
        {
          if (_context.SalaCines == null)
          {
              return NotFound();
          }
            var salaCine = await _context.SalaCines.FindAsync(id);

            if (salaCine == null)
            {
                return NotFound();
            }

            return salaCine;
        }

        // PUT: api/SalaCines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaCine(int id, SalaCine salaCine)
        {
            if (id != salaCine.IdSala)
            {
                return BadRequest();
            }

            _context.Entry(salaCine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaCineExists(id))
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

        // POST: api/SalaCines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaCine>> PostSalaCine(SalaCine salaCine)
        {
          if (_context.SalaCines == null)
          {
              return Problem("Entity set 'CineContext.SalaCines'  is null.");
          }
            _context.SalaCines.Add(salaCine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SalaCineExists(salaCine.IdSala))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSalaCine", new { id = salaCine.IdSala }, salaCine);
        }

        // DELETE: api/SalaCines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaCine(int id)
        {
            if (_context.SalaCines == null)
            {
                return NotFound();
            }
            var salaCine = await _context.SalaCines.FindAsync(id);
            if (salaCine == null)
            {
                return NotFound();
            }

            _context.SalaCines.Remove(salaCine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaCineExists(int id)
        {
            return (_context.SalaCines?.Any(e => e.IdSala == id)).GetValueOrDefault();
        }
    }
}
