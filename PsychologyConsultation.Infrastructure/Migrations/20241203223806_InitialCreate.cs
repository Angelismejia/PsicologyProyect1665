using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PsychologyConsultation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Detalles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuracionDias = table.Column<int>(type: "int", nullable: true),
                    ConsultaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeccionesSeguimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completada = table.Column<bool>(type: "bit", nullable: false),
                    TratamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionesSeguimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionesSeguimiento_Tratamientos_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionesSeguimiento_TratamientoId",
                table: "SeccionesSeguimiento",
                column: "TratamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_ConsultaId",
                table: "Tratamientos",
                column: "ConsultaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeccionesSeguimiento");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
