using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GavilanezJhostyn_ExamenU1_AS.Models;

namespace GavilanezJhostyn_ExamenU1_AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabecerasController : ControllerBase
    {
        private readonly GavilanezJFacturaExmContext _context;

        public CabecerasController(GavilanezJFacturaExmContext context)
        {
            _context = context;
        }

        // GET: api/Cabeceras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cabecera>>> GetCabeceras()
        {
            return await _context.Cabeceras.ToListAsync();
        }

        // GET: api/Cabeceras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cabecera>> GetCabecera(long id)
        {
            var cabecera = await _context.Cabeceras.FindAsync(id);

            if (cabecera == null)
            {
                return NotFound();
            }

            return cabecera;
        }

        // PUT: api/Cabeceras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCabecera(long id, Cabecera cabecera)
        {
            if (id != cabecera.Id)
            {
                return BadRequest();
            }

            _context.Entry(cabecera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabeceraExists(id))
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

        // POST: api/Cabeceras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cabecera>> PostCabecera(Cabecera cabecera)
        {
            _context.Cabeceras.Add(cabecera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCabecera", new { id = cabecera.Id }, cabecera);
        }

        // DELETE: api/Cabeceras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCabecera(long id)
        {
            var cabecera = await _context.Cabeceras.FindAsync(id);
            if (cabecera == null)
            {
                return NotFound();
            }

            _context.Cabeceras.Remove(cabecera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CabeceraExists(long id)
        {
            return _context.Cabeceras.Any(e => e.Id == id);
        }
    }
}
