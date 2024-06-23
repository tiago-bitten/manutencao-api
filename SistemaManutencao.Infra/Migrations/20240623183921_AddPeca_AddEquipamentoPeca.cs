using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPecaAddEquipamentoPeca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pecas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pecas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "equipamentos_pecas",
                columns: table => new
                {
                    equipamentoid = table.Column<Guid>(name: "equipamento_id", type: "uuid", nullable: false),
                    pecaid = table.Column<Guid>(name: "peca_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamentos_pecas", x => new { x.equipamentoid, x.pecaid });
                    table.ForeignKey(
                        name: "FK_equipamentos_pecas_equipamentos_equipamento_id",
                        column: x => x.equipamentoid,
                        principalTable: "equipamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_equipamentos_pecas_pecas_peca_id",
                        column: x => x.pecaid,
                        principalTable: "pecas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipamentos_pecas_peca_id",
                table: "equipamentos_pecas",
                column: "peca_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipamentos_pecas");

            migrationBuilder.DropTable(
                name: "pecas");
        }
    }
}
