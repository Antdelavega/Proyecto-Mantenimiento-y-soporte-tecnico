using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMantenimiento.Models
{
    public class Vehiculos
    {
        public int Id { get; set; }

       
        [Display(Name = "Numero de Placa")]
        public string NumeroPlaca { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Numero de Motor")]
        public string NumeroMotor { get; set; }

        //FK
        [ForeignKey("TipoVehiculo")]
        public int TipoVehiculoId { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }

        public ICollection<TipoActivos> TipoActivos { get; set; }


        


    }
}
