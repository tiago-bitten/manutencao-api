using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataconclusaoeanulavel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "manutencoes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_conclusao",
                table: "manutencoes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "data_inicio",
                table: "manutencoes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_conclusao",
                table: "manutencoes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
