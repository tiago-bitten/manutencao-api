using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Alterandorelaçãoentreproprietarioeempresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas");

            if (migrationBuilder.ActiveProvider == "Npgsql.EntityFrameworkCore.PostgreSQL")
            {
                migrationBuilder.Sql("ALTER TABLE proprietarios DROP COLUMN IF EXISTS \"EmpresaId\";");
            }

            migrationBuilder.CreateIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas",
                column: "proprietario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "proprietarios",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                unique: true);
        }
    }
}
