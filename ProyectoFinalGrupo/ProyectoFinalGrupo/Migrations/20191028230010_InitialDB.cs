using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinalGrupo.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Detalles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivoFijo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivoFijo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaseMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseMantenimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Detalles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DPI = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    FechaInicio = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaSolicitud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudTrabajo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFrecuencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFrecuencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaseActivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreClaseActivo = table.Column<string>(nullable: true),
                    ActivoFijoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaseActivos_ActivoFijo_ActivoFijoId",
                        column: x => x.ActivoFijoId,
                        principalTable: "ActivoFijo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Detalles = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoEmpleado_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aprobacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: true),
                    SolicitudTrabajoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprobacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aprobacion_SolicitudTrabajo_SolicitudTrabajoId",
                        column: x => x.SolicitudTrabajoId,
                        principalTable: "SolicitudTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    SolicitudTrabajoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleSolicitud_SolicitudTrabajo_SolicitudTrabajoId",
                        column: x => x.SolicitudTrabajoId,
                        principalTable: "SolicitudTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguridad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguridad_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreActivo = table.Column<string>(nullable: true),
                    ClaseActivosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activo_ClaseActivos_ClaseActivosId",
                        column: x => x.ClaseActivosId,
                        principalTable: "ClaseActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartamentosId = table.Column<int>(nullable: false),
                    AprobacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Aprobacion_AprobacionId",
                        column: x => x.AprobacionId,
                        principalTable: "Aprobacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Departamentos_DepartamentosId",
                        column: x => x.DepartamentosId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ActivoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Activo_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    OrdenTrabajoId = table.Column<int>(nullable: false),
                    EmpleadoId = table.Column<string>(nullable: true),
                    ClaseMantenimientoId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalles_ClaseMantenimiento_ClaseMantenimientoId",
                        column: x => x.ClaseMantenimientoId,
                        principalTable: "ClaseMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalles_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalles_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalles_OrdenTrabajo_OrdenTrabajoId",
                        column: x => x.OrdenTrabajoId,
                        principalTable: "OrdenTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActividadesId = table.Column<int>(nullable: false),
                    ClaseMantenimientoId = table.Column<int>(nullable: false),
                    ComponenteId = table.Column<int>(nullable: false),
                    TipoFrecuenciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programa_Actividades_ActividadesId",
                        column: x => x.ActividadesId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programa_ClaseMantenimiento_ClaseMantenimientoId",
                        column: x => x.ClaseMantenimientoId,
                        principalTable: "ClaseMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programa_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Programa_TipoFrecuencia_TipoFrecuenciaId",
                        column: x => x.TipoFrecuenciaId,
                        principalTable: "TipoFrecuencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activo_ClaseActivosId",
                table: "Activo",
                column: "ClaseActivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Aprobacion_SolicitudTrabajoId",
                table: "Aprobacion",
                column: "SolicitudTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaseActivos_ActivoFijoId",
                table: "ClaseActivos",
                column: "ActivoFijoId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_ActivoId",
                table: "Componente",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_ClaseMantenimientoId",
                table: "Detalles",
                column: "ClaseMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_ComponenteId",
                table: "Detalles",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_EmpleadoId",
                table: "Detalles",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_OrdenTrabajoId",
                table: "Detalles",
                column: "OrdenTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleSolicitud_SolicitudTrabajoId",
                table: "DetalleSolicitud",
                column: "SolicitudTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_AprobacionId",
                table: "OrdenTrabajo",
                column: "AprobacionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_DepartamentosId",
                table: "OrdenTrabajo",
                column: "DepartamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_ActividadesId",
                table: "Programa",
                column: "ActividadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_ClaseMantenimientoId",
                table: "Programa",
                column: "ClaseMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_ComponenteId",
                table: "Programa",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Programa_TipoFrecuenciaId",
                table: "Programa",
                column: "TipoFrecuenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguridad_UsuarioId",
                table: "Seguridad",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEmpleado_EmpleadoId",
                table: "TipoEmpleado",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "DetalleSolicitud");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropTable(
                name: "Seguridad");

            migrationBuilder.DropTable(
                name: "TipoEmpleado");

            migrationBuilder.DropTable(
                name: "OrdenTrabajo");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "ClaseMantenimiento");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "TipoFrecuencia");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Aprobacion");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Activo");

            migrationBuilder.DropTable(
                name: "SolicitudTrabajo");

            migrationBuilder.DropTable(
                name: "ClaseActivos");

            migrationBuilder.DropTable(
                name: "ActivoFijo");
        }
    }
}
