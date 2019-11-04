﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalGrupo.Models
{
    public class ClaseMantenimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //FK
        public ICollection<Detalles> Detalles { get; set; }

        public ICollection<Programa> Programas { get; set; }
    }
}