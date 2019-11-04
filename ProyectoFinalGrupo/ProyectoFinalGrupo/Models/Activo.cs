using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Activo
    {
        public int Id { get; set; }
        public string NombreActivo { get; set; }

        //FK
        public ICollection<Componente> Componentes { get; set; }

        [ForeignKey("ClaseActivos")]
        public int ClaseActivosId { get; set; }
        public ClaseActivos ClaseActivos { get; set; }

    }
}
