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
    public class AprobacionController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public AprobacionController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/Aprobacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aprobacion>>> GetAprobacion()
        {
            return await _context.Aprobacion.ToListAsync();
        }

        // GET: api/Aprobacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aprobacion>> GetAprobacion(int id)
        {
            var aprobacion = await _context.Aprobacion.FindAsync(id);

            if (aprobacion == null)
            {
                return NotFound();
            }

            return aprobacion;
        }

        // PUT: api/Aprobacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAprobacion(int id, Aprobacion aprobacion)
        {
            if (id != aprobacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(aprobacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AprobacionExists(id))
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

        // POST: api/Aprobacion
        [HttpPost]
        public async Task<ActionResult<Aprobacion>> PostAprobacion(Aprobacion aprobacion)
        {
            _context.Aprobacion.Add(aprobacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAprobacion", new { id = aprobacion.Id }, aprobacion);
        }

        // DELETE: api/Aprobacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aprobacion>> DeleteAprobacion(int id)
        {
            var aprobacion = await _context.Aprobacion.FindAsync(id);
            if (aprobacion == null)
            {
                return NotFound();
            }

            _context.Aprobacion.Remove(aprobacion);
            await _context.SaveChangesAsync();

            return aprobacion;
        }

        private bool AprobacionExists(int id)
        {
            return _context.Aprobacion.Any(e => e.Id == id);
        }
    }
}
