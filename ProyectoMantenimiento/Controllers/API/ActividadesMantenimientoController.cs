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
    public class ActividadesMantenimientoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public ActividadesMantenimientoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/ActividadesMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActividadesMantenimiento>>> GetActividadesMantenimiento()
        {
            return await _context.ActividadesMantenimiento.ToListAsync();
        }

        // GET: api/ActividadesMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActividadesMantenimiento>> GetActividadesMantenimiento(int id)
        {
            var actividadesMantenimiento = await _context.ActividadesMantenimiento.FindAsync(id);

            if (actividadesMantenimiento == null)
            {
                return NotFound();
            }

            return actividadesMantenimiento;
        }

        // PUT: api/ActividadesMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividadesMantenimiento(int id, ActividadesMantenimiento actividadesMantenimiento)
        {
            if (id != actividadesMantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividadesMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesMantenimientoExists(id))
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

        // POST: api/ActividadesMantenimiento
        [HttpPost]
        public async Task<ActionResult<ActividadesMantenimiento>> PostActividadesMantenimiento(ActividadesMantenimiento actividadesMantenimiento)
        {
            _context.ActividadesMantenimiento.Add(actividadesMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividadesMantenimiento", new { id = actividadesMantenimiento.Id }, actividadesMantenimiento);
        }

        // DELETE: api/ActividadesMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActividadesMantenimiento>> DeleteActividadesMantenimiento(int id)
        {
            var actividadesMantenimiento = await _context.ActividadesMantenimiento.FindAsync(id);
            if (actividadesMantenimiento == null)
            {
                return NotFound();
            }

            _context.ActividadesMantenimiento.Remove(actividadesMantenimiento);
            await _context.SaveChangesAsync();

            return actividadesMantenimiento;
        }

        private bool ActividadesMantenimientoExists(int id)
        {
            return _context.ActividadesMantenimiento.Any(e => e.Id == id);
        }
    }
}
