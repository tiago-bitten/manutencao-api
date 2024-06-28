using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    public partial class AdicionandoProprietario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "proprietario_id",
                table: "empresas",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "proprietarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UUID", nullable: false),
                    nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    telefone = table.Column<string>(type: "VARCHAR(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proprietarios", x => x.id);
                });

            var defaultProprietarioId = Guid.NewGuid();
            migrationBuilder.Sql($@"
                INSERT INTO proprietarios (id, nome, email, cpf, data_nascimento, telefone)
                VALUES ('{defaultProprietarioId}', 'Proprietario Padrão', 'proprietario@padrao.com', '00000000000', '2000-01-01', '00000000000')");

            migrationBuilder.Sql($@"
                UPDATE empresas
                SET proprietario_id = '{defaultProprietarioId}'
                WHERE proprietario_id IS NULL");

            migrationBuilder.AlterColumn<Guid>(
                name: "proprietario_id",
                table: "empresas",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_empresas_proprietarios_proprietario_id",
                table: "empresas",
                column: "proprietario_id",
                principalTable: "proprietarios",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empresas_proprietarios_proprietario_id",
                table: "empresas");

            migrationBuilder.DropTable(
                name: "proprietarios");

            migrationBuilder.DropIndex(
                name: "IX_empresas_proprietario_id",
                table: "empresas");

            migrationBuilder.DropColumn(
                name: "proprietario_id",
                table: "empresas");
        }
    }
}
