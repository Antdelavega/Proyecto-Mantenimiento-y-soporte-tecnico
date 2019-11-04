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
    public class TipoFrecuenciasController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public TipoFrecuenciasController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/TipoFrecuencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFrecuencia>>> GetTipoFrecuencia()
        {
            return await _context.TipoFrecuencia.ToListAsync();
        }

        // GET: api/TipoFrecuencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFrecuencia>> GetTipoFrecuencia(int id)
        {
            var tipoFrecuencia = await _context.TipoFrecuencia.FindAsync(id);

            if (tipoFrecuencia == null)
            {
                return NotFound();
            }

            return tipoFrecuencia;
        }

        // PUT: api/TipoFrecuencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoFrecuencia(int id, TipoFrecuencia tipoFrecuencia)
        {
            if (id != tipoFrecuencia.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoFrecuencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoFrecuenciaExists(id))
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

        // POST: api/TipoFrecuencias
        [HttpPost]
        public async Task<ActionResult<TipoFrecuencia>> PostTipoFrecuencia(TipoFrecuencia tipoFrecuencia)
        {
            _context.TipoFrecuencia.Add(tipoFrecuencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoFrecuencia", new { id = tipoFrecuencia.Id }, tipoFrecuencia);
        }

        // DELETE: api/TipoFrecuencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoFrecuencia>> DeleteTipoFrecuencia(int id)
        {
            var tipoFrecuencia = await _context.TipoFrecuencia.FindAsync(id);
            if (tipoFrecuencia == null)
            {
                return NotFound();
            }

            _context.TipoFrecuencia.Remove(tipoFrecuencia);
            await _context.SaveChangesAsync();

            return tipoFrecuencia;
        }

        private bool TipoFrecuenciaExists(int id)
        {
            return _context.TipoFrecuencia.Any(e => e.Id == id);
        }
    }
}
