using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneoFutbol.App.Persistencia.Migrations
{
    public partial class corregidaconpartidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionPartido_Partidos_PartidosId",
                table: "InformacionPartido");

            migrationBuilder.RenameColumn(
                name: "PartidosId",
                table: "InformacionPartido",
                newName: "PartidoId");

            migrationBuilder.RenameIndex(
                name: "IX_InformacionPartido_PartidosId",
                table: "InformacionPartido",
                newName: "IX_InformacionPartido_PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionPartido_Partidos_PartidoId",
                table: "InformacionPartido",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionPartido_Partidos_PartidoId",
                table: "InformacionPartido");

            migrationBuilder.RenameColumn(
                name: "PartidoId",
                table: "InformacionPartido",
                newName: "PartidosId");

            migrationBuilder.RenameIndex(
                name: "IX_InformacionPartido_PartidoId",
                table: "InformacionPartido",
                newName: "IX_InformacionPartido_PartidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionPartido_Partidos_PartidosId",
                table: "InformacionPartido",
                column: "PartidosId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
