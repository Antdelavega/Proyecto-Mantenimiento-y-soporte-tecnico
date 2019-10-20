using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class ActividadesMantenimiento
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Detalle { get; set; }
        [Required]
        public decimal Costo { get; set; }

        //FK
        public ICollection<InformeMantenimiento> InformeMantenimientos { get; set; }

        [ForeignKey("PeriodoMantenimiento")]
        public int PeriodoMantenimientoId { get; set; }
        public PeriodoMantenimiento PeriodoMantenimiento { get; set; }



    }
}
