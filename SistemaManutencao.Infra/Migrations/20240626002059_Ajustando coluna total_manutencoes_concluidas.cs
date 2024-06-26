using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Ajustandocolunatotalmanutencoesconcluidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total_manutencoes",
                table: "equipamentos",
                newName: "total_manutencoes_concluidas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total_manutencoes_concluidas",
                table: "equipamentos",
                newName: "total_manutencoes");
        }
    }
}
