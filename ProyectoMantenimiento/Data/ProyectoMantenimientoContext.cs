using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoMantenimiento.Models;

namespace ProyectoMantenimiento.Models
{
    public class ProyectoMantenimientoContext : DbContext
    {
        public ProyectoMantenimientoContext (DbContextOptions<ProyectoMantenimientoContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoMantenimiento.Models.ActividadesMantenimiento> ActividadesMantenimiento { get; set; }

        public DbSet<ProyectoMantenimiento.Models.ActivosFijos> ActivosFijos { get; set; }

        public DbSet<ProyectoMantenimiento.Models.Clientes> Clientes { get; set; }

        public DbSet<ProyectoMantenimiento.Models.Especialidad> Especialidad { get; set; }

        public DbSet<ProyectoMantenimiento.Models.Factura> Factura { get; set; }

        public DbSet<ProyectoMantenimiento.Models.InformeMantenimiento> InformeMantenimiento { get; set; }

        public DbSet<ProyectoMantenimiento.Models.Mecanico> Mecanico { get; set; }

        public DbSet<ProyectoMantenimiento.Models.OrdenTrabajo> OrdenTrabajo { get; set; }

        public DbSet<ProyectoMantenimiento.Models.PeriodoMantenimiento> PeriodoMantenimiento { get; set; }

        public DbSet<ProyectoMantenimiento.Models.PersonalMantenimiento> PersonalMantenimiento { get; set; }

        public DbSet<ProyectoMantenimiento.Models.PreventivoCorrectivo> PreventivoCorrectivo { get; set; }

        public DbSet<ProyectoMantenimiento.Models.TipoActivos> TipoActivos { get; set; }

        public DbSet<ProyectoMantenimiento.Models.TipoVehiculo> TipoVehiculo { get; set; }

        public DbSet<ProyectoMantenimiento.Models.Vehiculos> Vehiculos { get; set; }
    }
}
