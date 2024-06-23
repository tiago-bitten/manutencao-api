using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoIndicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_modelos_nome",
                table: "modelos",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_localizacoes_nome",
                table: "localizacoes",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_equipamentos_nome",
                table: "equipamentos",
                column: "nome");

            migrationBuilder.CreateIndex(
                name: "ix_categorias_nome",
                table: "categorias",
                column: "nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_modelos_nome",
                table: "modelos");

            migrationBuilder.DropIndex(
                name: "ix_localizacoes_nome",
                table: "localizacoes");

            migrationBuilder.DropIndex(
                name: "ix_equipamentos_nome",
                table: "equipamentos");

            migrationBuilder.DropIndex(
                name: "ix_categorias_nome",
                table: "categorias");
        }
    }
}
