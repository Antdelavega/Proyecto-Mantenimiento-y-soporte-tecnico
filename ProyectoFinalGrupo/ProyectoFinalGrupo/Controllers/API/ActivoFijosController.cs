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
    public class ActivoFijosController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public ActivoFijosController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/ActivoFijos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivoFijo>>> GetActivoFijo()
        {
            return await _context.ActivoFijo.ToListAsync();
        }

        // GET: api/ActivoFijos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivoFijo>> GetActivoFijo(int id)
        {
            var activoFijo = await _context.ActivoFijo.FindAsync(id);

            if (activoFijo == null)
            {
                return NotFound();
            }

            return activoFijo;
        }

        // PUT: api/ActivoFijos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivoFijo(int id, ActivoFijo activoFijo)
        {
            if (id != activoFijo.Id)
            {
                return BadRequest();
            }

            _context.Entry(activoFijo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivoFijoExists(id))
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

        // POST: api/ActivoFijos
        [HttpPost]
        public async Task<ActionResult<ActivoFijo>> PostActivoFijo(ActivoFijo activoFijo)
        {
            _context.ActivoFijo.Add(activoFijo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivoFijo", new { id = activoFijo.Id }, activoFijo);
        }

        // DELETE: api/ActivoFijos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivoFijo>> DeleteActivoFijo(int id)
        {
            var activoFijo = await _context.ActivoFijo.FindAsync(id);
            if (activoFijo == null)
            {
                return NotFound();
            }

            _context.ActivoFijo.Remove(activoFijo);
            await _context.SaveChangesAsync();

            return activoFijo;
        }

        private bool ActivoFijoExists(int id)
        {
            return _context.ActivoFijo.Any(e => e.Id == id);
        }
    }
}
