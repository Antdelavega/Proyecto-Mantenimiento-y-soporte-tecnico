using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class ActivoFijo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //FK

        public ICollection<ClaseActivos> ClaseActivos { get; set; }
    }
}
