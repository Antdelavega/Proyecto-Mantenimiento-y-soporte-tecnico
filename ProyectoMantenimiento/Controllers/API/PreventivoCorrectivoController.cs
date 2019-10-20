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
    public class PreventivoCorrectivoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public PreventivoCorrectivoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/PreventivoCorrectivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreventivoCorrectivo>>> GetPreventivoCorrectivo()
        {
            return await _context.PreventivoCorrectivo.ToListAsync();
        }

        // GET: api/PreventivoCorrectivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreventivoCorrectivo>> GetPreventivoCorrectivo(int id)
        {
            var preventivoCorrectivo = await _context.PreventivoCorrectivo.FindAsync(id);

            if (preventivoCorrectivo == null)
            {
                return NotFound();
            }

            return preventivoCorrectivo;
        }

        // PUT: api/PreventivoCorrectivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreventivoCorrectivo(int id, PreventivoCorrectivo preventivoCorrectivo)
        {
            if (id != preventivoCorrectivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(preventivoCorrectivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreventivoCorrectivoExists(id))
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

        // POST: api/PreventivoCorrectivo
        [HttpPost]
        public async Task<ActionResult<PreventivoCorrectivo>> PostPreventivoCorrectivo(PreventivoCorrectivo preventivoCorrectivo)
        {
            _context.PreventivoCorrectivo.Add(preventivoCorrectivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreventivoCorrectivo", new { id = preventivoCorrectivo.Id }, preventivoCorrectivo);
        }

        // DELETE: api/PreventivoCorrectivo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreventivoCorrectivo>> DeletePreventivoCorrectivo(int id)
        {
            var preventivoCorrectivo = await _context.PreventivoCorrectivo.FindAsync(id);
            if (preventivoCorrectivo == null)
            {
                return NotFound();
            }

            _context.PreventivoCorrectivo.Remove(preventivoCorrectivo);
            await _context.SaveChangesAsync();

            return preventivoCorrectivo;
        }

        private bool PreventivoCorrectivoExists(int id)
        {
            return _context.PreventivoCorrectivo.Any(e => e.Id == id);
        }
    }
}
