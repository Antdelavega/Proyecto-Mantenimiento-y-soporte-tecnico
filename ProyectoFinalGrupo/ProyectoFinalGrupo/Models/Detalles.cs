using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Detalles
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        //FK
        [ForeignKey("OrdenTrabajo")]
        public int OrdenTrabajoId { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }

        [ForeignKey("Empleado")]
        public string EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        [ForeignKey("ClaseMantenimiento")]
        public int ClaseMantenimientoId { get; set; }
        public ClaseMantenimiento ClaseMantenimiento { get; set; }

        [ForeignKey("Componente")]
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }
    }
}
