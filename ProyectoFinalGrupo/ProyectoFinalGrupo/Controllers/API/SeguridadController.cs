using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalGrupo.Models;

namespace ProyectoFinalGrupo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public SeguridadController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/Seguridad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seguridad>>> GetSeguridad()
        {
            return await _context.Seguridad.ToListAsync();
        }

        // GET: api/Seguridad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seguridad>> GetSeguridad(int id)
        {
            var seguridad = await _context.Seguridad.FindAsync(id);

            if (seguridad == null)
            {
                return NotFound();
            }

            return seguridad;
        }

        // PUT: api/Seguridad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeguridad(int id, Seguridad seguridad)
        {
            if (id != seguridad.Id)
            {
                return BadRequest();
            }

            _context.Entry(seguridad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguridadExists(id))
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

        // POST: api/Seguridad
        [HttpPost]
        public async Task<ActionResult<Seguridad>> PostSeguridad(Seguridad seguridad)
        {
            _context.Seguridad.Add(seguridad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeguridad", new { id = seguridad.Id }, seguridad);
        }

        // DELETE: api/Seguridad/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seguridad>> DeleteSeguridad(int id)
        {
            var seguridad = await _context.Seguridad.FindAsync(id);
            if (seguridad == null)
            {
                return NotFound();
            }

            _context.Seguridad.Remove(seguridad);
            await _context.SaveChangesAsync();

            return seguridad;
        }

        private bool SeguridadExists(int id)
        {
            return _context.Seguridad.Any(e => e.Id == id);
        }
    }
}
