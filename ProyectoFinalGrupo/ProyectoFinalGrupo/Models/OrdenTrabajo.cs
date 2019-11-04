using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }

        //FK
        // [ForeignKey("Asignacion")]
        //  public int AsignacionId { get; set; }
        //  public Asignacion Asignacion { get; set; }

        [ForeignKey("Departamentos")]
        public int DepartamentosId { get; set; }
        public Departamentos Departamentos { get; set; }

         [ForeignKey("Aprobacion")]
         public int AprobacionId { get; set; }
        public Aprobacion Aprobacion { get; set; }

        public ICollection<Detalles> Detalles { get; set; }
    }
}
