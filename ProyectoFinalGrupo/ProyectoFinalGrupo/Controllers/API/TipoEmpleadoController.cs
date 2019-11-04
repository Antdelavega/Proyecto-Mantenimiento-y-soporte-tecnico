using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProyectoFinalGrupo.Models;

namespace ProyectoFinalGrupo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEmpleadoController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public TipoEmpleadoController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //return View(await _context.TipoVehiculo.ToListAsync());

            return View(_context.Empleado
                .Include(t=> t.TipoEmpleados));
        
        }

        private IActionResult View(IIncludableQueryable<Empleado, ICollection<TipoEmpleado>> includableQueryable)
        {
            throw new NotImplementedException();
        }


        // GET: api/TipoEmpleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpleado>>> GetTipoEmpleado()
        {
            return await _context.TipoEmpleado.ToListAsync();
        }

        // GET: api/TipoEmpleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEmpleado>> GetTipoEmpleado(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);

            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            var tipoempleado = await _context.TipoEmpleado
                .Include(c => c.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);
    
           


            return tipoEmpleado;
        }

        // PUT: api/TipoEmpleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEmpleado(int id, TipoEmpleado tipoEmpleado)
        {
            if (id != tipoEmpleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEmpleadoExists(id))
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

        // POST: api/TipoEmpleado
        [HttpPost]
        public async Task<ActionResult<TipoEmpleado>> PostTipoEmpleado(TipoEmpleado tipoEmpleado)
        {
            _context.TipoEmpleado.Add(tipoEmpleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoEmpleado", new { id = tipoEmpleado.Id }, tipoEmpleado);
        }

        // DELETE: api/TipoEmpleado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEmpleado>> DeleteTipoEmpleado(int id)
        {
            var tipoEmpleado = await _context.TipoEmpleado.FindAsync(id);
            if (tipoEmpleado == null)
            {
                return NotFound();
            }

            _context.TipoEmpleado.Remove(tipoEmpleado);
            await _context.SaveChangesAsync();

            return tipoEmpleado;
        }

        private bool TipoEmpleadoExists(int id)
        {
            return _context.TipoEmpleado.Any(e => e.Id == id);
        }
    }
}
