using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class TipoVehiculo
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tipo")]
        public string Nombre { get; set; }
        //FK
        public ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
