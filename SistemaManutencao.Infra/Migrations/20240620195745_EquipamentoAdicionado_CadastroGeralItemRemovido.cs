using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class EquipamentoAdicionadoCadastroGeralItemRemovido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cadastro_geral_itens");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "modelos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "localizacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "categorias",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroDeSerie = table.Column<long>(type: "bigint", nullable: true),
                    DataAquisicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModeloId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocalizacaoId = table.Column<Guid>(type: "uuid", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamento_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "localizacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipamento_modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "modelos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_CategoriaId",
                table: "Equipamento",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_LocalizacaoId",
                table: "Equipamento",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ModeloId",
                table: "Equipamento",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "modelos",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "localizacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "categorias",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "cadastro_geral_itens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    categoriaid = table.Column<Guid>(name: "categoria_id", type: "uuid", nullable: false),
                    localizacaoid = table.Column<Guid>(name: "localizacao_id", type: "uuid", nullable: false),
                    modeloid = table.Column<Guid>(name: "modelo_id", type: "uuid", nullable: false),
                    dataaquisicao = table.Column<DateTime>(name: "data_aquisicao", type: "date", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    numeroserie = table.Column<long>(name: "numero_serie", type: "bigint", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    tipoitem = table.Column<string>(name: "tipo_item", type: "varchar(20)", nullable: false)
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
    }
}
