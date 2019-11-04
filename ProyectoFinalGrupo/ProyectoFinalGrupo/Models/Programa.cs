using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Programa
    {
        public int Id { get; set; }

        //FK
        [ForeignKey("Actividades")]
        public int ActividadesId { get; set; }
        public Actividades Actividades { get; set; }

        [ForeignKey("ClaseMantenimiento")]
        public int ClaseMantenimientoId { get; set; }
        public ClaseMantenimiento ClaseMantenimiento { get; set; }

        [ForeignKey("Componente")]
        public int ComponenteId { get; set; }
        public Componente Componente { get; set; }

        [ForeignKey("TipoFrecuencia")]
        public int TipoFrecuenciaId { get; set; }
        public TipoFrecuencia TipoFrecuencia { get; set; }

    }
}
