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
    public class InformeMantenimientoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public InformeMantenimientoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/InformeMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformeMantenimiento>>> GetInformeMantenimiento()
        {
            return await _context.InformeMantenimiento.ToListAsync();
        }

        // GET: api/InformeMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InformeMantenimiento>> GetInformeMantenimiento(int id)
        {
            var informeMantenimiento = await _context.InformeMantenimiento.FindAsync(id);

            if (informeMantenimiento == null)
            {
                return NotFound();
            }

            return informeMantenimiento;
        }

        // PUT: api/InformeMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInformeMantenimiento(int id, InformeMantenimiento informeMantenimiento)
        {
            if (id != informeMantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(informeMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InformeMantenimientoExists(id))
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

        // POST: api/InformeMantenimiento
        [HttpPost]
        public async Task<ActionResult<InformeMantenimiento>> PostInformeMantenimiento(InformeMantenimiento informeMantenimiento)
        {
            _context.InformeMantenimiento.Add(informeMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInformeMantenimiento", new { id = informeMantenimiento.Id }, informeMantenimiento);
        }

        // DELETE: api/InformeMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InformeMantenimiento>> DeleteInformeMantenimiento(int id)
        {
            var informeMantenimiento = await _context.InformeMantenimiento.FindAsync(id);
            if (informeMantenimiento == null)
            {
                return NotFound();
            }

            _context.InformeMantenimiento.Remove(informeMantenimiento);
            await _context.SaveChangesAsync();

            return informeMantenimiento;
        }

        private bool InformeMantenimientoExists(int id)
        {
            return _context.InformeMantenimiento.Any(e => e.Id == id);
        }
    }
}
