using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    public partial class correccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquiposId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EquiposId",
                table: "Jugadores",
                newName: "EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_EquiposId",
                table: "Jugadores",
                newName: "IX_Jugadores_EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores");

            migrationBuilder.RenameColumn(
                name: "EquipoId",
                table: "Jugadores",
                newName: "EquiposId");

            migrationBuilder.RenameIndex(
                name: "IX_Jugadores_EquipoId",
                table: "Jugadores",
                newName: "IX_Jugadores_EquiposId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquiposId",
                table: "Jugadores",
                column: "EquiposId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
