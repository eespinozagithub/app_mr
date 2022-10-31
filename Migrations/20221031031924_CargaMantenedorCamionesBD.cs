using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportesMR.Migrations
{
    public partial class CargaMantenedorCamionesBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaVehiculo",
                columns: table => new
                {
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaVehiculo", x => x.IdMarca);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoRemolques",
                columns: table => new
                {
                    IdTipoRemolque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    capacidad = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRemolques", x => x.IdTipoRemolque);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModeloVehiculo",
                columns: table => new
                {
                    IdModelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Modelo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdMarca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloVehiculo", x => x.IdModelo);
                    table.ForeignKey(
                        name: "FK_ModeloVehiculo_MarcaVehiculo_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "MarcaVehiculo",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    IdVehiculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Patente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroMotor = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Chasis = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Año = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Color = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdMarca = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCamion = table.Column<int>(type: "int", nullable: true),
                    Cilindrada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.IdVehiculo);
                    table.ForeignKey(
                        name: "FK_Vehiculos_MarcaVehiculo_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "MarcaVehiculo",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Remolques",
                columns: table => new
                {
                    IdRemolque = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Patente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CapacidadRemolque = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Año = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Color = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroRemolque = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdTipoRemolque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remolques", x => x.IdRemolque);
                    table.ForeignKey(
                        name: "FK_Remolques_TipoRemolques_IdTipoRemolque",
                        column: x => x.IdTipoRemolque,
                        principalTable: "TipoRemolques",
                        principalColumn: "IdTipoRemolque",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloVehiculo_IdMarca",
                table: "ModeloVehiculo",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Remolques_IdTipoRemolque",
                table: "Remolques",
                column: "IdTipoRemolque");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_IdMarca",
                table: "Vehiculos",
                column: "IdMarca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModeloVehiculo");

            migrationBuilder.DropTable(
                name: "Remolques");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "TipoRemolques");

            migrationBuilder.DropTable(
                name: "MarcaVehiculo");
        }
    }
}
