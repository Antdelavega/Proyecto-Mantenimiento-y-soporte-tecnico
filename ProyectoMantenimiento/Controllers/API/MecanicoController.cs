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
    public class MecanicoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public MecanicoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/Mecanico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mecanico>>> GetMecanico()
        {
            return await _context.Mecanico.ToListAsync();
        }

        // GET: api/Mecanico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mecanico>> GetMecanico(int id)
        {
            var mecanico = await _context.Mecanico.FindAsync(id);

            if (mecanico == null)
            {
                return NotFound();
            }

            return mecanico;
        }

        // PUT: api/Mecanico/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMecanico(int id, Mecanico mecanico)
        {
            if (id != mecanico.Id)
            {
                return BadRequest();
            }

            _context.Entry(mecanico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MecanicoExists(id))
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

        // POST: api/Mecanico
        [HttpPost]
        public async Task<ActionResult<Mecanico>> PostMecanico(Mecanico mecanico)
        {
            _context.Mecanico.Add(mecanico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMecanico", new { id = mecanico.Id }, mecanico);
        }

        // DELETE: api/Mecanico/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mecanico>> DeleteMecanico(int id)
        {
            var mecanico = await _context.Mecanico.FindAsync(id);
            if (mecanico == null)
            {
                return NotFound();
            }

            _context.Mecanico.Remove(mecanico);
            await _context.SaveChangesAsync();

            return mecanico;
        }

        private bool MecanicoExists(int id)
        {
            return _context.Mecanico.Any(e => e.Id == id);
        }
    }
}
