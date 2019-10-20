using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoMantenimiento.Models;

namespace ProyectoMantenimiento.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public TipoVehiculoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/TipoVehiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVehiculo>>> GetTipoVehiculo()
        {
            return await _context.TipoVehiculo.ToListAsync();
        }

        // GET: api/TipoVehiculo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVehiculo>> GetTipoVehiculo(int id)
        {
            var tipoVehiculo = await _context.TipoVehiculo.FindAsync(id);

            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            return tipoVehiculo;
        }

        // PUT: api/TipoVehiculo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVehiculo(int id, TipoVehiculo tipoVehiculo)
        {
            if (id != tipoVehiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoVehiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVehiculoExists(id))
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

        // POST: api/TipoVehiculo
        [HttpPost]
        public async Task<ActionResult<TipoVehiculo>> PostTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            _context.TipoVehiculo.Add(tipoVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVehiculo", new { id = tipoVehiculo.Id }, tipoVehiculo);
        }

        // DELETE: api/TipoVehiculo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoVehiculo>> DeleteTipoVehiculo(int id)
        {
            var tipoVehiculo = await _context.TipoVehiculo.FindAsync(id);
            if (tipoVehiculo == null)
            {
                return NotFound();
            }

            _context.TipoVehiculo.Remove(tipoVehiculo);
            await _context.SaveChangesAsync();

            return tipoVehiculo;
        }

        private bool TipoVehiculoExists(int id)
        {
            return _context.TipoVehiculo.Any(e => e.Id == id);
        }
    }
}
