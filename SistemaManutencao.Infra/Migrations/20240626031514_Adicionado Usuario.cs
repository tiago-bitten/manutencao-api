using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "possui_acesso",
                table: "tecnicos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    senhahash = table.Column<string>(name: "senha_hash", type: "varchar(1000)", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true),
                    tecnicoid = table.Column<Guid>(name: "tecnico_id", type: "uuid", nullable: true),
                    empresaid = table.Column<Guid>(name: "empresa_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_empresa_id",
                        column: x => x.empresaid,
                        principalTable: "empresas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuarios_tecnicos_tecnico_id",
                        column: x => x.tecnicoid,
                        principalTable: "tecnicos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_empresa_id",
                table: "usuarios",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_tecnico_id",
                table: "usuarios",
                column: "tecnico_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropColumn(
                name: "possui_acesso",
                table: "tecnicos");
        }
    }
}
