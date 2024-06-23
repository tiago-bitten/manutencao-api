using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPapel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PapelId",
                table: "ordens_servicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "papeis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_papeis", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordens_servicos_PapelId",
                table: "ordens_servicos",
                column: "PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ordens_servicos_papeis_PapelId",
                table: "ordens_servicos",
                column: "PapelId",
                principalTable: "papeis",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordens_servicos_papeis_PapelId",
                table: "ordens_servicos");

            migrationBuilder.DropTable(
                name: "papeis");

            migrationBuilder.DropIndex(
                name: "IX_ordens_servicos_PapelId",
                table: "ordens_servicos");

            migrationBuilder.DropColumn(
                name: "PapelId",
                table: "ordens_servicos");
        }
    }
}
