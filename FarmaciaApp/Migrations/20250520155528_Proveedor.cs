using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaciaApp.Migrations
{
    /// <inheritdoc />
    public partial class Proveedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proovedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComercial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rfc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegimenFiscal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proovedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProveedorMedicamentos",
                columns: table => new
                {
                    MedicamentoId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    piezas = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorMedicamentos", x => new { x.ProveedorId, x.MedicamentoId });
                    table.ForeignKey(
                        name: "FK_ProveedorMedicamentos_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProveedorMedicamentos_Proovedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proovedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProveedorMedicamentos_MedicamentoId",
                table: "ProveedorMedicamentos",
                column: "MedicamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProveedorMedicamentos");

            migrationBuilder.DropTable(
                name: "Proovedores");
        }
    }
}
