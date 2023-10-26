using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace BoletoService.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MigrationIncial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    PercentualJuros = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BancoId = table.Column<Guid>(type: "uuid", nullable: false),
                    NomePagador = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CpfCnpjPagador = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    NomeBeneficiario = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CpfCnpjBeneficiario = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(600)", maxLength: 600, nullable: true),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boletos_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancos_Codigo",
                table: "Bancos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bancos_Id",
                table: "Bancos",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_BancoId",
                table: "Boletos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Boletos_Id",
                table: "Boletos",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletos");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
