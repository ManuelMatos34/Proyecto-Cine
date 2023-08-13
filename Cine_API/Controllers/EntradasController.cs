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
    public class EntradasController : ControllerBase
    {
        private readonly CineContext _context;

        public EntradasController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Entradas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entrada>>> GetEntradas()
        {
          if (_context.Entradas == null)
          {
              return NotFound();
          }
            return await _context.Entradas.ToListAsync();
        }

        // GET: api/Entradas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entrada>> GetEntrada(int id)
        {
          if (_context.Entradas == null)
          {
              return NotFound();
          }
            var entrada = await _context.Entradas.FindAsync(id);

            if (entrada == null)
            {
                return NotFound();
            }

            return entrada;
        }

        // PUT: api/Entradas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntrada(int id, Entrada entrada)
        {
            if (id != entrada.IdEntradas)
            {
                return BadRequest();
            }

            _context.Entry(entrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradaExists(id))
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

        // POST: api/Entradas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entrada>> PostEntrada(Entrada entrada)
        {
          if (_context.Entradas == null)
          {
              return Problem("Entity set 'CineContext.Entradas'  is null.");
          }
            _context.Entradas.Add(entrada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntradaExists(entrada.IdEntradas))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEntrada", new { id = entrada.IdEntradas }, entrada);
        }

        // DELETE: api/Entradas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntrada(int id)
        {
            if (_context.Entradas == null)
            {
                return NotFound();
            }
            var entrada = await _context.Entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }

            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradaExists(int id)
        {
            return (_context.Entradas?.Any(e => e.IdEntradas == id)).GetValueOrDefault();
        }
    }
}
