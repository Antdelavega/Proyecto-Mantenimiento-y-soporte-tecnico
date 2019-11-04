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
    public class SolicitudTrabajoController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public SolicitudTrabajoController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/SolicitudTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolicitudTrabajo>>> GetSolicitudTrabajo()
        {
            return await _context.SolicitudTrabajo.ToListAsync();
        }

        // GET: api/SolicitudTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudTrabajo>> GetSolicitudTrabajo(int id)
        {
            var solicitudTrabajo = await _context.SolicitudTrabajo.FindAsync(id);

            if (solicitudTrabajo == null)
            {
                return NotFound();
            }

            return solicitudTrabajo;
        }

        // PUT: api/SolicitudTrabajo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitudTrabajo(int id, SolicitudTrabajo solicitudTrabajo)
        {
            if (id != solicitudTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(solicitudTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudTrabajoExists(id))
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

        // POST: api/SolicitudTrabajo
        [HttpPost]
        public async Task<ActionResult<SolicitudTrabajo>> PostSolicitudTrabajo(SolicitudTrabajo solicitudTrabajo)
        {
            _context.SolicitudTrabajo.Add(solicitudTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitudTrabajo", new { id = solicitudTrabajo.Id }, solicitudTrabajo);
        }

        // DELETE: api/SolicitudTrabajo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SolicitudTrabajo>> DeleteSolicitudTrabajo(int id)
        {
            var solicitudTrabajo = await _context.SolicitudTrabajo.FindAsync(id);
            if (solicitudTrabajo == null)
            {
                return NotFound();
            }

            _context.SolicitudTrabajo.Remove(solicitudTrabajo);
            await _context.SaveChangesAsync();

            return solicitudTrabajo;
        }

        private bool SolicitudTrabajoExists(int id)
        {
            return _context.SolicitudTrabajo.Any(e => e.Id == id);
        }
    }
}
