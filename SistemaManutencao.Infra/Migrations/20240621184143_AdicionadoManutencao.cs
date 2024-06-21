using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoManutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manutencoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    datainicio = table.Column<DateTime>(name: "data_inicio", type: "timestamp", nullable: false),
                    dataconclusao = table.Column<DateTime>(name: "data_conclusao", type: "timestamp", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    tipomanutencao = table.Column<string>(name: "tipo_manutencao", type: "text", nullable: false),
                    equipamentoid = table.Column<Guid>(name: "equipamento_id", type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manutencoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_manutencoes_equipamentos_equipamento_id",
                        column: x => x.equipamentoid,
                        principalTable: "equipamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_manutencoes_equipamento_id",
                table: "manutencoes",
                column: "equipamento_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manutencoes");
        }
    }
}
