using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPecaUtilizada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pecas_usadas",
                columns: table => new
                {
                    pecaid = table.Column<Guid>(name: "peca_id", type: "uuid", nullable: false),
                    manutencaoid = table.Column<Guid>(name: "manutencao_id", type: "uuid", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pecas_usadas", x => new { x.pecaid, x.manutencaoid });
                    table.ForeignKey(
                        name: "FK_pecas_usadas_manutencoes_manutencao_id",
                        column: x => x.manutencaoid,
                        principalTable: "manutencoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pecas_usadas_pecas_peca_id",
                        column: x => x.pecaid,
                        principalTable: "pecas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pecas_usadas_manutencao_id",
                table: "pecas_usadas",
                column: "manutencao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pecas_usadas");
        }
    }
}
