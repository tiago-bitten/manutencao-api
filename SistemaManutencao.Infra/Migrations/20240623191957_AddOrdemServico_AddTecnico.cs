using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdemServicoAddTecnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tecnicos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    datanascimento = table.Column<DateTime>(name: "data_nascimento", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tecnicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ordens_servicos",
                columns: table => new
                {
                    manutencaoid = table.Column<Guid>(name: "manutencao_id", type: "uuid", nullable: false),
                    tecnicoid = table.Column<Guid>(name: "tecnico_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordens_servicos", x => new { x.manutencaoid, x.tecnicoid });
                    table.ForeignKey(
                        name: "FK_ordens_servicos_manutencoes_manutencao_id",
                        column: x => x.manutencaoid,
                        principalTable: "manutencoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ordens_servicos_tecnicos_tecnico_id",
                        column: x => x.tecnicoid,
                        principalTable: "tecnicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordens_servicos_tecnico_id",
                table: "ordens_servicos",
                column: "tecnico_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordens_servicos");

            migrationBuilder.DropTable(
                name: "tecnicos");
        }
    }
}
