using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class TipoActivos
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del  Activo")]
        public string Nombre { get; set; }

        //FK
        [ForeignKey("Vehiculos")]
        public int VehiculosId { get; set; }
        public Vehiculos Vehiculos { get; set; }

        public ICollection<ActivosFijos> ActivosFijos { get; set; }

    }
}
