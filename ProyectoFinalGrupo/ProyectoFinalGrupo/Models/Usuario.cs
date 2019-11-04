using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string FechaNacimiento { get; set; }
        public string Rol { get; set; }

        public ICollection<Seguridad> Seguridades { get; set; }
    }
}
