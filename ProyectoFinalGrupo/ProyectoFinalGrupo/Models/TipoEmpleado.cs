using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class TipoEmpleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }

        [ForeignKey("Empleado")]
        public string EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
    }
}
