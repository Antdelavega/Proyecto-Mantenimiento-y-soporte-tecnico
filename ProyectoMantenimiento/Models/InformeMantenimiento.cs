using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class InformeMantenimiento
    {
        public int Id { get; set; } //no
        

        [Required]
        [Display(Name = "Fecha Entrega")]
        public string FechaEntrega { get; set; }

        [Required]
        [Display(Name = "Fecha Salida")]
        public string FechaSalida { get; set; }

        [Required]  
        [Display(Name = "Prioridad ")]
        public string Prioridad { get; set; }


        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Tipo de Mantenimiento")]
        public String TipoMantenimiento { get; set; }

        //FK

       
        [ForeignKey("ActivosFijos")]
        public int ActivosFijosId { get; set; }
        public ActivosFijos ActivosFijos { get; set; }


        [ForeignKey("ActividadesMantenimiento")]
        public int ActividadesMantenimientoId { get; set; }
        public ActividadesMantenimiento ActividadesMantenimiento { get; set; }

        [ForeignKey("PersonalMantenimiento")]
        public int PersonalMantenimientoId { get; set; }
        public PersonalMantenimiento PersonalMantenimiento { get; set; }

       
        public ICollection<Factura> Facturas { get; set; }

    }
}
