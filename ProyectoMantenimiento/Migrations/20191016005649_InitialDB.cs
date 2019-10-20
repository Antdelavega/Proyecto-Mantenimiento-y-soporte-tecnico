using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoMantenimiento.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Nit = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: false),
                    FechaSalida = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoMantenimiento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreventivoCorrectivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Defecto_observado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreventivoCorrectivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVehiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVehiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mecanico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    DPI = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecanico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mecanico_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DPI = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    EspecialidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalMantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalMantenimiento_Especialidad_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadesMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    PeriodoMantenimientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadesMantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadesMantenimiento_PeriodoMantenimiento_PeriodoMantenimientoId",
                        column: x => x.PeriodoMantenimientoId,
                        principalTable: "PeriodoMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroPlaca = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    NumeroMotor = table.Column<string>(nullable: false),
                    TipoVehiculoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_TipoVehiculo_TipoVehiculoId",
                        column: x => x.TipoVehiculoId,
                        principalTable: "TipoVehiculo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeriodicidadEntrega = table.Column<string>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    PreventivoCorrectivoId = table.Column<int>(nullable: false),
                    MecanicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Mecanico_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mecanico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_PreventivoCorrectivo_PreventivoCorrectivoId",
                        column: x => x.PreventivoCorrectivoId,
                        principalTable: "PreventivoCorrectivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoActivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    VehiculosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoActivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoActivos_Vehiculos_VehiculosId",
                        column: x => x.VehiculosId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    TipoActivosId = table.Column<int>(nullable: false),
                    ClientesId = table.Column<int>(nullable: false),
                    OrdenTrabajoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivosFijos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_Clientes_ClientesId",
                        column: x => x.ClientesId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_OrdenTrabajo_OrdenTrabajoId",
                        column: x => x.OrdenTrabajoId,
                        principalTable: "OrdenTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivosFijos_TipoActivos_TipoActivosId",
                        column: x => x.TipoActivosId,
                        principalTable: "TipoActivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformeMantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaEntrega = table.Column<string>(nullable: false),
                    FechaSalida = table.Column<string>(nullable: false),
                    Prioridad = table.Column<string>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    TipoMantenimiento = table.Column<string>(nullable: false),
                    ActivosFijosId = table.Column<int>(nullable: false),
                    PersonalMantenimientoId = table.Column<int>(nullable: false),
                    ActividadesMantenimientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformeMantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformeMantenimiento_ActividadesMantenimiento_ActividadesMantenimientoId",
                        column: x => x.ActividadesMantenimientoId,
                        principalTable: "ActividadesMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformeMantenimiento_ActivosFijos_ActivosFijosId",
                        column: x => x.ActivosFijosId,
                        principalTable: "ActivosFijos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformeMantenimiento_PersonalMantenimiento_PersonalMantenimientoId",
                        column: x => x.PersonalMantenimientoId,
                        principalTable: "PersonalMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaFacturacion = table.Column<DateTime>(nullable: false),
                    Detalles = table.Column<string>(nullable: false),
                    InformeMantenimientoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_InformeMantenimiento_InformeMantenimientoId",
                        column: x => x.InformeMantenimientoId,
                        principalTable: "InformeMantenimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadesMantenimiento_PeriodoMantenimientoId",
                table: "ActividadesMantenimiento",
                column: "PeriodoMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_ClientesId",
                table: "ActivosFijos",
                column: "ClientesId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_OrdenTrabajoId",
                table: "ActivosFijos",
                column: "OrdenTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_TipoActivosId",
                table: "ActivosFijos",
                column: "TipoActivosId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_InformeMantenimientoId",
                table: "Factura",
                column: "InformeMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformeMantenimiento_ActividadesMantenimientoId",
                table: "InformeMantenimiento",
                column: "ActividadesMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_InformeMantenimiento_ActivosFijosId",
                table: "InformeMantenimiento",
                column: "ActivosFijosId");

            migrationBuilder.CreateIndex(
                name: "IX_InformeMantenimiento_PersonalMantenimientoId",
                table: "InformeMantenimiento",
                column: "PersonalMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mecanico_EspecialidadId",
                table: "Mecanico",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_MecanicoId",
                table: "OrdenTrabajo",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_PreventivoCorrectivoId",
                table: "OrdenTrabajo",
                column: "PreventivoCorrectivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalMantenimiento_EspecialidadId",
                table: "PersonalMantenimiento",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoActivos_VehiculosId",
                table: "TipoActivos",
                column: "VehiculosId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TipoVehiculoId",
                table: "Vehiculos",
                column: "TipoVehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "InformeMantenimiento");

            migrationBuilder.DropTable(
                name: "ActividadesMantenimiento");

            migrationBuilder.DropTable(
                name: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "PersonalMantenimiento");

            migrationBuilder.DropTable(
                name: "PeriodoMantenimiento");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "OrdenTrabajo");

            migrationBuilder.DropTable(
                name: "TipoActivos");

            migrationBuilder.DropTable(
                name: "Mecanico");

            migrationBuilder.DropTable(
                name: "PreventivoCorrectivo");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "TipoVehiculo");
        }
    }
}
