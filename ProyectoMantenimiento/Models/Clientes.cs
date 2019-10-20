using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Nit")]
        public string Nit { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int Telefono { get; set; }

        //FK
        public ICollection<ActivosFijos> ActivosFijos { get; set; }
    }
}
