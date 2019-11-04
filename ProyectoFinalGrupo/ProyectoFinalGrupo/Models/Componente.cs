using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Componente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //FK

        public ICollection<Detalles> Detalles { get; set; }
        public ICollection<Programa> Programas { get; set; }

        [ForeignKey("Activo")]
        public int ActivoId { get; set; }
        public Activo Activo { get; set; }
    }
}
