using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Aprobacion
    {

        public int Id { get; set; }
        public string Estado { get; set; }

        //FK

        [ForeignKey("SolicitudTrabajo")]
        public int SolicitudTrabajoId { get; set; }
        public SolicitudTrabajo SolicitudTrabajo { get; set; }
         public ICollection<OrdenTrabajo> OrdenTrabajo { get; set; }
    }
}
