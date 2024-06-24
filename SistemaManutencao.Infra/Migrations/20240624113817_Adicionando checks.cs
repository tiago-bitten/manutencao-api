using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    public partial class Adicionandochecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "manutencoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_manutencao",
                table: "manutencoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.Sql(@"
                ALTER TABLE manutencoes
                ADD CONSTRAINT chk_status_manutencao CHECK (status IN ('Pendente', 'EmAndamento', 'Concluido', 'Encerrado'))
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE manutencoes
                ADD CONSTRAINT chk_tipo_manutencao CHECK (tipo_manutencao IN ('Preventiva', 'Corretiva'))
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE manutencoes
                DROP CONSTRAINT chk_status_manutencao
            ");

            migrationBuilder.Sql(@"
                ALTER TABLE manutencoes
                DROP CONSTRAINT chk_tipo_manutencao
            ");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "manutencoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "tipo_manutencao",
                table: "manutencoes",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
