using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundaEvaluacion.Shared.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Personas_PersonaId",
                table: "Paises");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_PaisId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Paises_PersonaId",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Paises");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Personas",
                newName: "NacionalidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_PaisId",
                table: "Personas",
                newName: "IX_Personas_NacionalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_NacionalidadId",
                table: "Personas",
                column: "NacionalidadId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Paises_NacionalidadId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "NacionalidadId",
                table: "Personas",
                newName: "PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_NacionalidadId",
                table: "Personas",
                newName: "IX_Personas_PaisId");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Paises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_PersonaId",
                table: "Paises",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Personas_PersonaId",
                table: "Paises",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Paises_PaisId",
                table: "Personas",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
