using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class addEspecializacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordens_servicos_papeis_PapelId",
                table: "ordens_servicos");

            migrationBuilder.RenameColumn(
                name: "PapelId",
                table: "ordens_servicos",
                newName: "papel_id");

            migrationBuilder.RenameIndex(
                name: "IX_ordens_servicos_PapelId",
                table: "ordens_servicos",
                newName: "IX_ordens_servicos_papel_id");

            migrationBuilder.AddColumn<Guid>(
                name: "especializacao_id",
                table: "tecnicos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "especializacoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especializacoes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tecnicos_especializacao_id",
                table: "tecnicos",
                column: "especializacao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ordens_servicos_papeis_papel_id",
                table: "ordens_servicos",
                column: "papel_id",
                principalTable: "papeis",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tecnicos_especializacoes_especializacao_id",
                table: "tecnicos",
                column: "especializacao_id",
                principalTable: "especializacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordens_servicos_papeis_papel_id",
                table: "ordens_servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_tecnicos_especializacoes_especializacao_id",
                table: "tecnicos");

            migrationBuilder.DropTable(
                name: "especializacoes");

            migrationBuilder.DropIndex(
                name: "IX_tecnicos_especializacao_id",
                table: "tecnicos");

            migrationBuilder.DropColumn(
                name: "especializacao_id",
                table: "tecnicos");

            migrationBuilder.RenameColumn(
                name: "papel_id",
                table: "ordens_servicos",
                newName: "PapelId");

            migrationBuilder.RenameIndex(
                name: "IX_ordens_servicos_papel_id",
                table: "ordens_servicos",
                newName: "IX_ordens_servicos_PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ordens_servicos_papeis_PapelId",
                table: "ordens_servicos",
                column: "PapelId",
                principalTable: "papeis",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
