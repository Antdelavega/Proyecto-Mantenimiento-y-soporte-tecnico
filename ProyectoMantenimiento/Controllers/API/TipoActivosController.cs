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
    public class TipoActivosController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public TipoActivosController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/TipoActivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoActivos>>> GetTipoActivos()
        {
            return await _context.TipoActivos.ToListAsync();
        }

        // GET: api/TipoActivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoActivos>> GetTipoActivos(int id)
        {
            var tipoActivos = await _context.TipoActivos.FindAsync(id);

            if (tipoActivos == null)
            {
                return NotFound();
            }

            return tipoActivos;
        }

        // PUT: api/TipoActivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoActivos(int id, TipoActivos tipoActivos)
        {
            if (id != tipoActivos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoActivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoActivosExists(id))
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

        // POST: api/TipoActivos
        [HttpPost]
        public async Task<ActionResult<TipoActivos>> PostTipoActivos(TipoActivos tipoActivos)
        {
            _context.TipoActivos.Add(tipoActivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoActivos", new { id = tipoActivos.Id }, tipoActivos);
        }

        // DELETE: api/TipoActivos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoActivos>> DeleteTipoActivos(int id)
        {
            var tipoActivos = await _context.TipoActivos.FindAsync(id);
            if (tipoActivos == null)
            {
                return NotFound();
            }

            _context.TipoActivos.Remove(tipoActivos);
            await _context.SaveChangesAsync();

            return tipoActivos;
        }

        private bool TipoActivosExists(int id)
        {
            return _context.TipoActivos.Any(e => e.Id == id);
        }
    }
}
