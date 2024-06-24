using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandoindicesemtodosascolunasnome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_tecnicos_nome",
                table: "tecnicos",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_pecas_nome",
                table: "pecas",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_papeis_nome",
                table: "papeis",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_ferramentas_nome",
                table: "ferramentas",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_especializacoes_nome",
                table: "especializacoes",
                column: "nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_tecnicos_nome",
                table: "tecnicos");

            migrationBuilder.DropIndex(
                name: "ix_pecas_nome",
                table: "pecas");

            migrationBuilder.DropIndex(
                name: "ix_papeis_nome",
                table: "papeis");

            migrationBuilder.DropIndex(
                name: "ix_ferramentas_nome",
                table: "ferramentas");

            migrationBuilder.DropIndex(
                name: "ix_especializacoes_nome",
                table: "especializacoes");
        }
    }
}
