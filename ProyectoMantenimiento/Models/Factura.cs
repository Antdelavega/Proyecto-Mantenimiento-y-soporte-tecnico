using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha Facturación")]
        public DateTime FechaFacturacion { get; set; }

        [Required]
        public string Detalles { get; set; }

        //FK

        [ForeignKey("InformeMantenimiento")]
        public int InformeMantenimientoId { get; set; }
        public InformeMantenimiento InformeMantenimiento { get; set; }
    }
}
