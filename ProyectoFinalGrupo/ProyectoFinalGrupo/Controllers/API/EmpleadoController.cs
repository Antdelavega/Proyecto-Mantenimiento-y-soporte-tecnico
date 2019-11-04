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
    public class EmpleadoController : ControllerBase
    {
        private readonly ProyectoFinalGrupoContext _context;

        public EmpleadoController(ProyectoFinalGrupoContext context)
        {
            _context = context;
        }

      
        public IEnumerable<Empleado> GetOrdenT()
        {
            return _context.Empleado
                .Include(c => c.TipoEmpleados);



        }

        public ActionResult Index()
        {
            using (Models.ProyectoFinalGrupoContext db = new Models.ProyectoFinalGrupoContext())
            {
                var list = (from u in db.Empleado
                            join t in db.TipoEmpleado
                            on u.Id equals t.EmpleadoId
                     
                            select new
                            {
                            id = u.Id,
                            nombre = u.Nombre,
                            apellidos = u.Apellido,
                            dpi = u.DPI,
                            fechaInicio = u.FechaInicio,
                            fechaNacimiento = u.FechaNacimiento,
                            telefono = u.Telefono,
                            direccion = u.Direccion,
                            idt = t.Id,
                            nombret = t.Nombre,
                            detallest = t.Detalles

                            }).ToList();
                return Ok(list);
            }
            
            // return Index(list);


        }
 
        private IActionResult View(IIncludableQueryable<TipoEmpleado, Empleado> includableQueryable)
        {
            throw new NotImplementedException();
        }
      [HttpGet]
        // GET: api/Empleado

        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleado()
        {
            return await _context.Empleado.ToListAsync();


        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string id)
        {
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(string id, Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
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

        // POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleado.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleado>> DeleteEmpleado(string id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();

            return empleado;
        }

        private bool EmpleadoExists(string id)
        {
            return _context.Empleado.Any(e => e.Id == id);
        }
    }
}
