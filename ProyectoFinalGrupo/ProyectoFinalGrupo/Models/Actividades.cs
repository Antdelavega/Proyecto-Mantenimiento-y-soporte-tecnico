using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Actividades
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }

        //FK
        public ICollection<Programa> Programas { get; set; }
    }
}
