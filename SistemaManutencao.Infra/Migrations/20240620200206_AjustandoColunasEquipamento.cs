using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoColunasEquipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_categorias_CategoriaId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_localizacoes_LocalizacaoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_modelos_ModeloId",
                table: "Equipamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipamento",
                table: "Equipamento");

            migrationBuilder.RenameTable(
                name: "Equipamento",
                newName: "equipamentos");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "equipamentos",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "equipamentos",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "equipamentos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NumeroDeSerie",
                table: "equipamentos",
                newName: "numero_de_serie");

            migrationBuilder.RenameColumn(
                name: "ModeloId",
                table: "equipamentos",
                newName: "modelo_id");

            migrationBuilder.RenameColumn(
                name: "LocalizacaoId",
                table: "equipamentos",
                newName: "localizacao_id");

            migrationBuilder.RenameColumn(
                name: "DataAquisicao",
                table: "equipamentos",
                newName: "data_aquisicao");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "equipamentos",
                newName: "categoria_id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_ModeloId",
                table: "equipamentos",
                newName: "IX_equipamentos_modelo_id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_LocalizacaoId",
                table: "equipamentos",
                newName: "IX_equipamentos_localizacao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_CategoriaId",
                table: "equipamentos",
                newName: "IX_equipamentos_categoria_id");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "equipamentos",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "data_aquisicao",
                table: "equipamentos",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_equipamentos",
                table: "equipamentos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos",
                column: "categoria_id",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos",
                column: "localizacao_id",
                principalTable: "localizacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos",
                column: "modelo_id",
                principalTable: "modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_categorias_categoria_id",
                table: "equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_localizacoes_localizacao_id",
                table: "equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_modelos_modelo_id",
                table: "equipamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_equipamentos",
                table: "equipamentos");

            migrationBuilder.RenameTable(
                name: "equipamentos",
                newName: "Equipamento");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Equipamento",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Equipamento",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Equipamento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "numero_de_serie",
                table: "Equipamento",
                newName: "NumeroDeSerie");

            migrationBuilder.RenameColumn(
                name: "modelo_id",
                table: "Equipamento",
                newName: "ModeloId");

            migrationBuilder.RenameColumn(
                name: "localizacao_id",
                table: "Equipamento",
                newName: "LocalizacaoId");

            migrationBuilder.RenameColumn(
                name: "data_aquisicao",
                table: "Equipamento",
                newName: "DataAquisicao");

            migrationBuilder.RenameColumn(
                name: "categoria_id",
                table: "Equipamento",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_equipamentos_modelo_id",
                table: "Equipamento",
                newName: "IX_Equipamento_ModeloId");

            migrationBuilder.RenameIndex(
                name: "IX_equipamentos_localizacao_id",
                table: "Equipamento",
                newName: "IX_Equipamento_LocalizacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_equipamentos_categoria_id",
                table: "Equipamento",
                newName: "IX_Equipamento_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Equipamento",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAquisicao",
                table: "Equipamento",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipamento",
                table: "Equipamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_categorias_CategoriaId",
                table: "Equipamento",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_localizacoes_LocalizacaoId",
                table: "Equipamento",
                column: "LocalizacaoId",
                principalTable: "localizacoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_modelos_ModeloId",
                table: "Equipamento",
                column: "ModeloId",
                principalTable: "modelos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
