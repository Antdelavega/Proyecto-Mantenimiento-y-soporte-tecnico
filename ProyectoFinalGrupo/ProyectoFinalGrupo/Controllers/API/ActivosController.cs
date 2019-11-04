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
    public class ActivosController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public ActivosController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/Activos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activo>>> GetActivo()
        {
            return await _context.Activo.ToListAsync();
        }

        // GET: api/Activos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activo>> GetActivo(int id)
        {
            var activo = await _context.Activo.FindAsync(id);

            if (activo == null)
            {
                return NotFound();
            }

            return activo;
        }

        // PUT: api/Activos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivo(int id, Activo activo)
        {
            if (id != activo.Id)
            {
                return BadRequest();
            }

            _context.Entry(activo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoExists(id))
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

        // POST: api/Activos
        [HttpPost]
        public async Task<ActionResult<Activo>> PostActivo(Activo activo)
        {
            _context.Activo.Add(activo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivo", new { id = activo.Id }, activo);
        }

        // DELETE: api/Activos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Activo>> DeleteActivo(int id)
        {
            var activo = await _context.Activo.FindAsync(id);
            if (activo == null)
            {
                return NotFound();
            }

            _context.Activo.Remove(activo);
            await _context.SaveChangesAsync();

            return activo;
        }

        private bool ActivoExists(int id)
        {
            return _context.Activo.Any(e => e.Id == id);
        }
    }
}
