using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportesMR.Migrations
{
    public partial class CreaTablaCiudad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vueltas_Ciudades_CiudadesIdCiudad",
                table: "Vueltas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vueltas_Empresa_IdEmpresaDescarga",
                table: "Vueltas");

            migrationBuilder.DropIndex(
                name: "IX_Vueltas_IdEmpresaDescarga",
                table: "Vueltas");

            migrationBuilder.RenameColumn(
                name: "IdRegionDescarga",
                table: "Vueltas",
                newName: "IdCiudadDescarga");

            migrationBuilder.RenameColumn(
                name: "IdRegionCarga",
                table: "Vueltas",
                newName: "IdCiudadCarga");

            migrationBuilder.RenameColumn(
                name: "CiudadesIdCiudad",
                table: "Vueltas",
                newName: "CiudadDescargaIdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_Vueltas_CiudadesIdCiudad",
                table: "Vueltas",
                newName: "IX_Vueltas_CiudadDescargaIdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Vueltas_IdCiudadCarga",
                table: "Vueltas",
                column: "IdCiudadCarga");

            migrationBuilder.CreateIndex(
                name: "IX_Vueltas_IdCiudadDescarga",
                table: "Vueltas",
                column: "IdCiudadDescarga");

            migrationBuilder.AddForeignKey(
                name: "FK_Vueltas_Ciudades_CiudadDescargaIdCiudad",
                table: "Vueltas",
                column: "CiudadDescargaIdCiudad",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Vueltas_Ciudades_IdCiudadCarga",
                table: "Vueltas",
                column: "IdCiudadCarga",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Vueltas_Empresa_IdCiudadDescarga",
                table: "Vueltas",
                column: "IdCiudadDescarga",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vueltas_Ciudades_CiudadDescargaIdCiudad",
                table: "Vueltas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vueltas_Ciudades_IdCiudadCarga",
                table: "Vueltas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vueltas_Empresa_IdCiudadDescarga",
                table: "Vueltas");

            migrationBuilder.DropIndex(
                name: "IX_Vueltas_IdCiudadCarga",
                table: "Vueltas");

            migrationBuilder.DropIndex(
                name: "IX_Vueltas_IdCiudadDescarga",
                table: "Vueltas");

            migrationBuilder.RenameColumn(
                name: "IdCiudadDescarga",
                table: "Vueltas",
                newName: "IdRegionDescarga");

            migrationBuilder.RenameColumn(
                name: "IdCiudadCarga",
                table: "Vueltas",
                newName: "IdRegionCarga");

            migrationBuilder.RenameColumn(
                name: "CiudadDescargaIdCiudad",
                table: "Vueltas",
                newName: "CiudadesIdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_Vueltas_CiudadDescargaIdCiudad",
                table: "Vueltas",
                newName: "IX_Vueltas_CiudadesIdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Vueltas_IdEmpresaDescarga",
                table: "Vueltas",
                column: "IdEmpresaDescarga");

            migrationBuilder.AddForeignKey(
                name: "FK_Vueltas_Ciudades_CiudadesIdCiudad",
                table: "Vueltas",
                column: "CiudadesIdCiudad",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Vueltas_Empresa_IdEmpresaDescarga",
                table: "Vueltas",
                column: "IdEmpresaDescarga",
                principalTable: "Empresa",
                principalColumn: "IdEmpresa");
        }
    }
}
