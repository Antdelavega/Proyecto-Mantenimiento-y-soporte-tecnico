using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class SolicitudTrabajo
    {
        public int Id { get; set; }
        public string FechaSolicitud { get; set; }

        public ICollection<DetalleSolicitud> DetalleSolicitudes { get; set; }
        public ICollection<Aprobacion> Aprobacion { get; set; }
    }
}
