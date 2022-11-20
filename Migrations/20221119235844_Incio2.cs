using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportesMR.Migrations
{
    public partial class Incio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "ModeloVehiculo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "MarcaVehiculo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Remolque_IdModelo",
                table: "Remolque",
                column: "IdModelo");

            migrationBuilder.AddForeignKey(
                name: "FK_Remolque_ModeloRemolque_IdModelo",
                table: "Remolque",
                column: "IdModelo",
                principalTable: "ModeloRemolque",
                principalColumn: "IdModelo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remolque_ModeloRemolque_IdModelo",
                table: "Remolque");

            migrationBuilder.DropIndex(
                name: "IX_Remolque_IdModelo",
                table: "Remolque");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ModeloVehiculo");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "MarcaVehiculo");
        }
    }
}
