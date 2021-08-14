using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundaEvaluacion.Shared.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    dni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPais = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NombrePais = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Personadni = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paises_Personas_Personadni",
                        column: x => x.Personadni,
                        principalTable: "Personas",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Personadni",
                table: "Paises",
                column: "Personadni");

            migrationBuilder.CreateIndex(
                name: "UQ_Pais_Cod",
                table: "Paises",
                column: "CodPais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_dni",
                table: "Personas",
                column: "dni",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
