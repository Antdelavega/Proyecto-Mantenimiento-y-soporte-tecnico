using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalGrupo.Models;

namespace ProyectoFinalGrupo.Models
{
    public class ProyectoFinalGrupoContext : DbContext
    {
        public ProyectoFinalGrupoContext()
        {
        }

        public ProyectoFinalGrupoContext (DbContextOptions<ProyectoFinalGrupoContext> options) : base(options)
        {
        }

        public DbSet<ProyectoFinalGrupo.Models.Actividades> Actividades { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Activo> Activo { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.ActivoFijo> ActivoFijo { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Aprobacion> Aprobacion { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.ClaseActivos> ClaseActivos { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.ClaseMantenimiento> ClaseMantenimiento { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Componente> Componente { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Departamentos> Departamentos { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Detalles> Detalles { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.DetalleSolicitud> DetalleSolicitud { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Empleado> Empleado { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.OrdenTrabajo> OrdenTrabajo { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Programa> Programa { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Seguridad> Seguridad { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.SolicitudTrabajo> SolicitudTrabajo { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.TipoEmpleado> TipoEmpleado { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.TipoFrecuencia> TipoFrecuencia { get; set; }

        public DbSet<ProyectoFinalGrupo.Models.Usuario> Usuario { get; set; }
    }
}
