using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MapeandocolunasNomeeDescriçãoemManutencao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "manutencoes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "manutencoes",
                newName: "descricao");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "manutencoes",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "idx_manutencoes_nome",
                table: "manutencoes",
                column: "nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_manutencoes_nome",
                table: "manutencoes");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "manutencoes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "manutencoes",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "manutencoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");
        }
    }
}
