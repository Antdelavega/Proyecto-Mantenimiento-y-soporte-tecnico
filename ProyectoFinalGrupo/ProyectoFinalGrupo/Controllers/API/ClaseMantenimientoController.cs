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
    public class ClaseMantenimientoController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public ClaseMantenimientoController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/ClaseMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseMantenimiento>>> GetClaseMantenimiento()
        {
            return await _context.ClaseMantenimiento.ToListAsync();
        }

        // GET: api/ClaseMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseMantenimiento>> GetClaseMantenimiento(int id)
        {
            var claseMantenimiento = await _context.ClaseMantenimiento.FindAsync(id);

            if (claseMantenimiento == null)
            {
                return NotFound();
            }

            return claseMantenimiento;
        }

        // PUT: api/ClaseMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaseMantenimiento(int id, ClaseMantenimiento claseMantenimiento)
        {
            if (id != claseMantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(claseMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseMantenimientoExists(id))
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

        // POST: api/ClaseMantenimiento
        [HttpPost]
        public async Task<ActionResult<ClaseMantenimiento>> PostClaseMantenimiento(ClaseMantenimiento claseMantenimiento)
        {
            _context.ClaseMantenimiento.Add(claseMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaseMantenimiento", new { id = claseMantenimiento.Id }, claseMantenimiento);
        }

        // DELETE: api/ClaseMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClaseMantenimiento>> DeleteClaseMantenimiento(int id)
        {
            var claseMantenimiento = await _context.ClaseMantenimiento.FindAsync(id);
            if (claseMantenimiento == null)
            {
                return NotFound();
            }

            _context.ClaseMantenimiento.Remove(claseMantenimiento);
            await _context.SaveChangesAsync();

            return claseMantenimiento;
        }

        private bool ClaseMantenimientoExists(int id)
        {
            return _context.ClaseMantenimiento.Any(e => e.Id == id);
        }
    }
}
