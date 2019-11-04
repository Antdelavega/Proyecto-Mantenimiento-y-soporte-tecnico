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
    public class DetalleSolicitudController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public DetalleSolicitudController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/DetalleSolicitud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleSolicitud>>> GetDetalleSolicitud()
        {
            return await _context.DetalleSolicitud.ToListAsync();
        }

        // GET: api/DetalleSolicitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleSolicitud>> GetDetalleSolicitud(int id)
        {
            var detalleSolicitud = await _context.DetalleSolicitud.FindAsync(id);

            if (detalleSolicitud == null)
            {
                return NotFound();
            }

            return detalleSolicitud;
        }

        // PUT: api/DetalleSolicitud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleSolicitud(int id, DetalleSolicitud detalleSolicitud)
        {
            if (id != detalleSolicitud.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleSolicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleSolicitudExists(id))
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

        // POST: api/DetalleSolicitud
        [HttpPost]
        public async Task<ActionResult<DetalleSolicitud>> PostDetalleSolicitud(DetalleSolicitud detalleSolicitud)
        {
            _context.DetalleSolicitud.Add(detalleSolicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleSolicitud", new { id = detalleSolicitud.Id }, detalleSolicitud);
        }

        // DELETE: api/DetalleSolicitud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleSolicitud>> DeleteDetalleSolicitud(int id)
        {
            var detalleSolicitud = await _context.DetalleSolicitud.FindAsync(id);
            if (detalleSolicitud == null)
            {
                return NotFound();
            }

            _context.DetalleSolicitud.Remove(detalleSolicitud);
            await _context.SaveChangesAsync();

            return detalleSolicitud;
        }

        private bool DetalleSolicitudExists(int id)
        {
            return _context.DetalleSolicitud.Any(e => e.Id == id);
        }
    }
}
