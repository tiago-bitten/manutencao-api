using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SetandocomonullcolunacategoriaidemEquipamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos",
                column: "categoria_id",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos");

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos",
                column: "categoria_id",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
