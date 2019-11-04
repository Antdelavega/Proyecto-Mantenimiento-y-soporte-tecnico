using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class Empleado
    {
        public string Id { get; set; } //Carnet
        public int DPI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string FechaInicio { get; set; }

        public string FechaNacimiento { get; set; }

        public int Telefono { get; set; }
        public string Direccion { get; set; }

        //FK
        public ICollection<Detalles> Detalles { get; set; }
        public ICollection<TipoEmpleado> TipoEmpleados { get; set; }
    }
}
