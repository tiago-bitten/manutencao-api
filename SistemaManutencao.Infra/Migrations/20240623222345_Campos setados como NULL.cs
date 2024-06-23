using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CampossetadoscomoNULL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos",
                column: "localizacao_id",
                principalTable: "localizacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos",
                column: "modelo_id",
                principalTable: "modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos",
                column: "localizacao_id",
                principalTable: "localizacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos",
                column: "modelo_id",
                principalTable: "modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
