using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class ActivosFijos
    {
     
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

        //FK

        [ForeignKey("TipoActivos")]
        public int TipoActivosId { get; set; }
        public TipoActivos TipoActivos { get; set; }

        [ForeignKey("Clientes")]
        public int ClientesId { get; set; }
        public Clientes Clientes { get; set; }

        [ForeignKey("OrdenTrabajo")]
        public int OrdenTrabajoId { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }

        public ICollection<InformeMantenimiento> InformeMantenimientos { get; set; }
        
    }
}
