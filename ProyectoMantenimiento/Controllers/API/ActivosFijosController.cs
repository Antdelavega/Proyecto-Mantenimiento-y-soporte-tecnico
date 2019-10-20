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
    public class ActivosFijosController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public ActivosFijosController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/ActivosFijos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivosFijos>>> GetActivosFijos()
        {
            return await _context.ActivosFijos.ToListAsync();
        }

        // GET: api/ActivosFijos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivosFijos>> GetActivosFijos(int id)
        {
            var activosFijos = await _context.ActivosFijos.FindAsync(id);

            if (activosFijos == null)
            {
                return NotFound();
            }

            return activosFijos;
        }

        // PUT: api/ActivosFijos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivosFijos(int id, ActivosFijos activosFijos)
        {
            if (id != activosFijos.Id)
            {
                return BadRequest();
            }

            _context.Entry(activosFijos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivosFijosExists(id))
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

        // POST: api/ActivosFijos
        [HttpPost]
        public async Task<ActionResult<ActivosFijos>> PostActivosFijos(ActivosFijos activosFijos)
        {
            _context.ActivosFijos.Add(activosFijos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivosFijos", new { id = activosFijos.Id }, activosFijos);
        }

        // DELETE: api/ActivosFijos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivosFijos>> DeleteActivosFijos(int id)
        {
            var activosFijos = await _context.ActivosFijos.FindAsync(id);
            if (activosFijos == null)
            {
                return NotFound();
            }

            _context.ActivosFijos.Remove(activosFijos);
            await _context.SaveChangesAsync();

            return activosFijos;
        }

        private bool ActivosFijosExists(int id)
        {
            return _context.ActivosFijos.Any(e => e.Id == id);
        }
    }
}
