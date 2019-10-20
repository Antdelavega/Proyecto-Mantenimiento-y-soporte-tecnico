using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class Especialidad
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre de especialidad")]
        public string Nombre { get; set; }

        //FK
        public ICollection<Mecanico> Mecanicos { get; set; }
        public ICollection<PersonalMantenimiento> PersonalMantenimientos { get; set; }
    }
}
