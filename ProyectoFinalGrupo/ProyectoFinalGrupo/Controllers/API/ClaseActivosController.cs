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
    public class ClaseActivosController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public ClaseActivosController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/ClaseActivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClaseActivos>>> GetClaseActivos()
        {
            return await _context.ClaseActivos.ToListAsync();
        }

        // GET: api/ClaseActivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseActivos>> GetClaseActivos(int id)
        {
            var claseActivos = await _context.ClaseActivos.FindAsync(id);

            if (claseActivos == null)
            {
                return NotFound();
            }

            return claseActivos;
        }

        // PUT: api/ClaseActivos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaseActivos(int id, ClaseActivos claseActivos)
        {
            if (id != claseActivos.Id)
            {
                return BadRequest();
            }

            _context.Entry(claseActivos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaseActivosExists(id))
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

        // POST: api/ClaseActivos
        [HttpPost]
        public async Task<ActionResult<ClaseActivos>> PostClaseActivos(ClaseActivos claseActivos)
        {
            _context.ClaseActivos.Add(claseActivos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaseActivos", new { id = claseActivos.Id }, claseActivos);
        }

        // DELETE: api/ClaseActivos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClaseActivos>> DeleteClaseActivos(int id)
        {
            var claseActivos = await _context.ClaseActivos.FindAsync(id);
            if (claseActivos == null)
            {
                return NotFound();
            }

            _context.ClaseActivos.Remove(claseActivos);
            await _context.SaveChangesAsync();

            return claseActivos;
        }

        private bool ClaseActivosExists(int id)
        {
            return _context.ClaseActivos.Any(e => e.Id == id);
        }
    }
}
