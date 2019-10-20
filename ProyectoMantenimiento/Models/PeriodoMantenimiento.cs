using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class PeriodoMantenimiento
    {
        public int Id { get; set; }

        [Required]
        public string  Nombre { get; set; }

        [Required]
        [Display(Name = "Hora de Entrega")]
        public DateTime FechaEntrega { get; set; }

        [Required]
        [Display(Name = "Hora de Salida")]
        public DateTime FechaSalida { get; set; }

        //FK
        public ICollection<ActividadesMantenimiento> GetActividadesMantenimientos { get; set; }

    }
}
