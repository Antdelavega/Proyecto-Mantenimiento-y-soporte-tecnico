using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class PersonalMantenimiento
    {
        public int Id { get; set; }
        [Required]
        public string DPI { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }

        //FK

        public ICollection<InformeMantenimiento> InformeMantenimientos { get; set; }

        [ForeignKey("Especialidad")]
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }

    }
}
