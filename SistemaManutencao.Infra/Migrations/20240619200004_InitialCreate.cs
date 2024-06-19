using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "localizacoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localizacoes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modelos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modelos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cadastro_geral_itens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    numeroserie = table.Column<long>(name: "numero_serie", type: "bigint", nullable: false),
                    dataaquisicao = table.Column<DateTime>(name: "data_aquisicao", type: "date", nullable: false),
                    modeloid = table.Column<Guid>(name: "modelo_id", type: "uuid", nullable: false),
                    localizacaoid = table.Column<Guid>(name: "localizacao_id", type: "uuid", nullable: false),
                    categoriaid = table.Column<Guid>(name: "categoria_id", type: "uuid", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    tipoitem = table.Column<string>(name: "tipo_item", type: "varchar(20)", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cadastro_geral_itens", x => x.id);
                    table.ForeignKey(
                        name: "FK_cadastro_geral_itens_categorias_categoria_id",
                        column: x => x.categoriaid,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cadastro_geral_itens_localizacoes_localizacao_id",
                        column: x => x.localizacaoid,
                        principalTable: "localizacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cadastro_geral_itens_modelos_modelo_id",
                        column: x => x.modeloid,
                        principalTable: "modelos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cadastro_geral_itens_categoria_id",
                table: "cadastro_geral_itens",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_cadastro_geral_itens_localizacao_id",
                table: "cadastro_geral_itens",
                column: "localizacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_cadastro_geral_itens_modelo_id",
                table: "cadastro_geral_itens",
                column: "modelo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastro_geral_itens");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "localizacoes");

            migrationBuilder.DropTable(
                name: "modelos");
        }
    }
}
