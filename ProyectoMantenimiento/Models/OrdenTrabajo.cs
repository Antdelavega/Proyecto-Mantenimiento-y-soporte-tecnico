using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class OrdenTrabajo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Periodo de Entrega")]
        public string PeriodicidadEntrega { get; set; }

        [Required]
        public decimal Costo { get; set; }

        //FK
        [ForeignKey("PreventivoCorrectivo")]
        public int PreventivoCorrectivoId { get; set; }
        public PreventivoCorrectivo PreventivoCorrectivo { get; set; }

        [ForeignKey("Mecanico")]
        public int MecanicoId { get; set; }
        public Mecanico Mecanico { get; set; }

        public ICollection<ActivosFijos> ActivosFijos { get; set; }
    }
}
