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
    public class PersonalMantenimientoController : ControllerBase
    {
        private readonly ProyectoMantenimientoContext _context;

        public PersonalMantenimientoController(ProyectoMantenimientoContext context)
        {
            _context = context;
        }

        // GET: api/PersonalMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalMantenimiento>>> GetPersonalMantenimiento()
        {
            return await _context.PersonalMantenimiento.ToListAsync();
        }

        // GET: api/PersonalMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalMantenimiento>> GetPersonalMantenimiento(int id)
        {
            var personalMantenimiento = await _context.PersonalMantenimiento.FindAsync(id);

            if (personalMantenimiento == null)
            {
                return NotFound();
            }

            return personalMantenimiento;
        }

        // PUT: api/PersonalMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalMantenimiento(int id, PersonalMantenimiento personalMantenimiento)
        {
            if (id != personalMantenimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalMantenimientoExists(id))
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

        // POST: api/PersonalMantenimiento
        [HttpPost]
        public async Task<ActionResult<PersonalMantenimiento>> PostPersonalMantenimiento(PersonalMantenimiento personalMantenimiento)
        {
            _context.PersonalMantenimiento.Add(personalMantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalMantenimiento", new { id = personalMantenimiento.Id }, personalMantenimiento);
        }

        // DELETE: api/PersonalMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalMantenimiento>> DeletePersonalMantenimiento(int id)
        {
            var personalMantenimiento = await _context.PersonalMantenimiento.FindAsync(id);
            if (personalMantenimiento == null)
            {
                return NotFound();
            }

            _context.PersonalMantenimiento.Remove(personalMantenimiento);
            await _context.SaveChangesAsync();

            return personalMantenimiento;
        }

        private bool PersonalMantenimientoExists(int id)
        {
            return _context.PersonalMantenimiento.Any(e => e.Id == id);
        }
    }
}
