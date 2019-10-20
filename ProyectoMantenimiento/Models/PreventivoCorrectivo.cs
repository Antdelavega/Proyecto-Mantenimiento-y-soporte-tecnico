using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class PreventivoCorrectivo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Detalles del defecto ")]
        public string Defecto_observado { get; set; }

        //FK
        public ICollection<OrdenTrabajo> OrdenTrabajos { get; set; }

    }
}
