using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandocolunaAtivoemtodastabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "tecnicos",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "proprietarios",
                type: "BOOLEAN",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "pecas",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "papeis",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "modelos",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "manutencoes",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "localizacoes",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "ferramentas",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "especializacoes",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "equipamentos",
                type: "boolean",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "categorias",
                type: "boolean",
                nullable: true,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ativo",
                table: "tecnicos");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "proprietarios");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "pecas");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "papeis");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "modelos");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "localizacoes");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "ferramentas");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "especializacoes");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "equipamentos");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "categorias");
        }
    }
}
