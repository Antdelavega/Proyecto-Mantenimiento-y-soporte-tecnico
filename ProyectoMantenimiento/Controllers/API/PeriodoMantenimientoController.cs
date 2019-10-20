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
    public class PeriodoMantenimientoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public PeriodoMantenimientoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/PeriodoMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoMantenimiento>>> GetPeriodoMantenimiento()
        {
            return await _context.PeriodoMantenimiento.ToListAsync();
        }

        // GET: api/PeriodoMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodoMantenimiento>> GetPeriodoMantenimiento(int id)
        {
            var periodoMantenimiento = await _context.PeriodoMantenimiento.FindAsync(id);

            if (periodoMantenimiento == null)
            {
                return NotFound();
            }

            return periodoMantenimiento;
        }

        // PUT: api/PeriodoMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodoMantenimiento(int id, PeriodoMantenimiento periodoMantenimiento)
        {
            if (id != periodoMantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(periodoMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoMantenimientoExists(id))
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

        // POST: api/PeriodoMantenimiento
        [HttpPost]
        public async Task<ActionResult<PeriodoMantenimiento>> PostPeriodoMantenimiento(PeriodoMantenimiento periodoMantenimiento)
        {
            _context.PeriodoMantenimiento.Add(periodoMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodoMantenimiento", new { id = periodoMantenimiento.Id }, periodoMantenimiento);
        }

        // DELETE: api/PeriodoMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PeriodoMantenimiento>> DeletePeriodoMantenimiento(int id)
        {
            var periodoMantenimiento = await _context.PeriodoMantenimiento.FindAsync(id);
            if (periodoMantenimiento == null)
            {
                return NotFound();
            }

            _context.PeriodoMantenimiento.Remove(periodoMantenimiento);
            await _context.SaveChangesAsync();

            return periodoMantenimiento;
        }

        private bool PeriodoMantenimientoExists(int id)
        {
            return _context.PeriodoMantenimiento.Any(e => e.Id == id);
        }
    }
}
