using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class DetalleSolicitud
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        //FK Detalle -1 SolicitudTrabajo

        [ForeignKey("SolicitudTrabajo")]
        public int SolicitudTrabajoId { get; set; }
        public SolicitudTrabajo SolicitudTrabajo { get; set; }
    }
}
