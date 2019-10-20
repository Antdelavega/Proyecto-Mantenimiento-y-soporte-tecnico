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
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public OrdenTrabajoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/OrdenTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenTrabajo>>> GetOrdenTrabajo()
        {
            return await _context.OrdenTrabajo.ToListAsync();
        }

        // GET: api/OrdenTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenTrabajo>> GetOrdenTrabajo(int id)
        {
            var ordenTrabajo = await _context.OrdenTrabajo.FindAsync(id);

            if (ordenTrabajo == null)
            {
                return NotFound();
            }

            return ordenTrabajo;
        }

        // PUT: api/OrdenTrabajo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenTrabajo(int id, OrdenTrabajo ordenTrabajo)
        {
            if (id != ordenTrabajo.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenTrabajoExists(id))
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

        // POST: api/OrdenTrabajo
        [HttpPost]
        public async Task<ActionResult<OrdenTrabajo>> PostOrdenTrabajo(OrdenTrabajo ordenTrabajo)
        {
            _context.OrdenTrabajo.Add(ordenTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenTrabajo", new { id = ordenTrabajo.Id }, ordenTrabajo);
        }

        // DELETE: api/OrdenTrabajo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenTrabajo>> DeleteOrdenTrabajo(int id)
        {
            var ordenTrabajo = await _context.OrdenTrabajo.FindAsync(id);
            if (ordenTrabajo == null)
            {
                return NotFound();
            }

            _context.OrdenTrabajo.Remove(ordenTrabajo);
            await _context.SaveChangesAsync();

            return ordenTrabajo;
        }

        private bool OrdenTrabajoExists(int id)
        {
            return _context.OrdenTrabajo.Any(e => e.Id == id);
        }
    }
}
