using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GavilanezJhostyn_ExamenU1_AS.Models;
using GavilanezJhostyn_ExamenU1_AS.DTOs;

namespace GavilanezJhostyn_ExamenU1_AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesController : ControllerBase
    {
        private readonly GavilanezJFacturaExmContext _context;

        public DetallesController(GavilanezJFacturaExmContext context)
        {
            _context = context;
        }

        // GET: api/Detalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalle>>> GetDetalles()
        {
            return await _context.Detalles.ToListAsync();
        }

        // GET: api/Detalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Detalle>> GetDetalle(long id)
        {
            var detalle = await _context.Detalles.FindAsync(id);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // PUT: api/Detalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(long id, Detalle detalle)
        {
            if (id != detalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/
        // PUT: api/Detalles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(long id, DetallesDTO detallesDTO)
        {
            if (id != detallesDTO.Id)
            {
                return BadRequest();
            }

            var detalle = await _context.Detalles.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            detalle.CabeceraId = detallesDTO.CabeceraId;
            detalle.ProductoId = detallesDTO.ProductoId;
            detalle.Cantidad = detallesDTO.Cantidad;
            detalle.Precio = detallesDTO.Precio;

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleExists(id))
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


        // POST: api/Detalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
         public async Task<ActionResult<Detalle>> PostDetalle(Detalle detalle)
         {
             _context.Detalles.Add(detalle);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetDetalle", new { id = detalle.Id }, detalle);
         }*/
        // POST: api/Detalles
        [HttpPost]
        public async Task<ActionResult<Detalle>> PostDetalle(DetallesDTO detallesDTO)
        {
            var detalle = new Detalle
            {
                
                CabeceraId = detallesDTO.CabeceraId,
                ProductoId = detallesDTO.ProductoId,
                Cantidad = detallesDTO.Cantidad,
                Precio = detallesDTO.Precio
                
            };

            _context.Detalles.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalle", new { id = detalle.Id }, detalle);
        }


        // DELETE: api/Detalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalle(long id)
        {
            var detalle = await _context.Detalles.FindAsync(id);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleExists(long id)
        {
            return _context.Detalles.Any(e => e.Id == id);
        }
    }
}
