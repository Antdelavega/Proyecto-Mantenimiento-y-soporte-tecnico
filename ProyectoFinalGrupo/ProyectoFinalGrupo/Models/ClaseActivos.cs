using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class ClaseActivos
    {
        public int Id { get; set; }
        public string NombreClaseActivo { get; set; }

        //FK
        public ICollection<Activo> Activos { get; set; }

        [ForeignKey("ActivoFijo")]
        public int ActivoFijoId { get; set; }
        public ActivoFijo ActivoFijo { get; set; }
    }
}
