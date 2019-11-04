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
    public class ComponentesController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public ComponentesController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        // GET: api/Componentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Componente>>> GetComponente()
        {
            return await _context.Componente.ToListAsync();
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Componente>> GetComponente(int id)
        {
            var componente = await _context.Componente.FindAsync(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        // PUT: api/Componentes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponente(int id, Componente componente)
        {
            if (id != componente.Id)
            {
                return BadRequest();
            }

            _context.Entry(componente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteExists(id))
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

        // POST: api/Componentes
        [HttpPost]
        public async Task<ActionResult<Componente>> PostComponente(Componente componente)
        {
            _context.Componente.Add(componente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponente", new { id = componente.Id }, componente);
        }

        // DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Componente>> DeleteComponente(int id)
        {
            var componente = await _context.Componente.FindAsync(id);
            if (componente == null)
            {
                return NotFound();
            }

            _context.Componente.Remove(componente);
            await _context.SaveChangesAsync();

            return componente;
        }

        private bool ComponenteExists(int id)
        {
            return _context.Componente.Any(e => e.Id == id);
        }
    }
}
