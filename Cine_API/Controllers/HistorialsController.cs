using Microsoft.AspNetCore.Mvc;
using Cine_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly CineContext _context;

        public HistorialsController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorials()
        {
            return await _context.Historials.ToListAsync();
        }

        // GET api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var historial = await _context.Historials.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // POST api/Historials
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial([FromBody] Historial historial)
        {
            _context.Historials.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorial", new { id = historial.IdRegistro }, historial);
        }

        // PUT api/Historials/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, [FromBody] Historial historial)
        {
            if (id != historial.IdRegistro)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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

        // DELETE api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var historial = await _context.Historials.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historials.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialExists(int id)
        {
            return _context.Historials.Any(e => e.IdRegistro == id);
        }
    }
}
