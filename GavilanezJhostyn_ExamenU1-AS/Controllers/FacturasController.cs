using GavilanezJhostyn_ExamenU1_AS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace GavilanezJhostyn_ExamenU1_AS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly GavilanezJFacturaExmContext _context;

        public FacturasController(GavilanezJFacturaExmContext context)
        {
            _context = context;
        }

        // Get: /Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetFacturas()
        {
            var facturas = await _context.Cabeceras 
                .Select(c => new
                {
                    Cabecera = c,
                    Detalles = c.Detalles,
                    Subtotal = c.Detalles.Sum(d => d.Cantidad * d.Precio),
                    IVA = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 0.12m, // Asumiendo un IVA del 12%
                    Total = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 1.12m
                })
                .ToListAsync();

            return facturas;
        }

        // Get: /Facturas/Cliente/{cliente}
        [HttpGet("Cliente/{cliente}")]
        public async Task<ActionResult<IEnumerable<object>>> GetFacturasPorCliente(string cliente)
        {
            var facturas = await _context.Cabeceras 
                .Where(c => c.Cliente == cliente)
                .Select(c => new
                {
                    Cabecera = c,
                    Detalles = c.Detalles,
                    Subtotal = c.Detalles.Sum(d => d.Cantidad * d.Precio),
                    IVA = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 0.12m,
                    Total = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 1.12m
                })
                .ToListAsync();

            return facturas;
        }

        // Get: /Facturas/Valor/{valor}
        [HttpGet("Valor/{valor}")]
        public async Task<ActionResult<IEnumerable<object>>> GetFacturasPorValor(decimal valor)
        {
            var facturas = await _context.Cabeceras 
                .Select(c => new
                {
                    Cabecera = c,
                    Detalles = c.Detalles,
                    Subtotal = c.Detalles.Sum(d => d.Cantidad * d.Precio),
                    IVA = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 0.12m,
                    Total = c.Detalles.Sum(d => d.Cantidad * d.Precio) * 1.12m
                })
                .Where(f => f.Total > valor)
                .ToListAsync();

            return facturas;
        }
    }
}
