using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    public partial class AdicionadotabelaEmpresaTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "tecnicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "pecas_usadas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "pecas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "papeis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "ordens_servicos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "modelos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "manutencoes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "localizacoes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "ferramentas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "especializacoes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "equipamentos_pecas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "equipamentos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "empresa_id",
                table: "categorias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "empresas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    cpfcnpj = table.Column<string>(name: "cpf_cnpj", type: "varchar(14)", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    tipoempresa = table.Column<string>(name: "tipo_empresa", type: "text", nullable: false),
                    telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    endereco = table.Column<string>(type: "varchar(150)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    estado = table.Column<string>(type: "varchar(2)", nullable: true),
                    cep = table.Column<string>(type: "varchar(8)", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.id);
                });

            migrationBuilder.Sql(@"
                INSERT INTO empresas (id, nome, cpf_cnpj, email, tipo_empresa, telefone, endereco, cidade, estado, cep, ativo)
                VALUES ('00000000-0000-0000-0000-000000000000', 'Empresa Padrão', '00000000000000', 'email@empresa.com', 'TipoEmpresa', '0000000000', 'Endereco', 'Cidade', 'ES', '00000000', true)
                ON CONFLICT DO NOTHING;
            ");

            migrationBuilder.Sql(@"
                UPDATE tecnicos
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE pecas_usadas
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE pecas
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE papeis
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE ordens_servicos
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE modelos
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE manutencoes
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE localizacoes
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE ferramentas
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE especializacoes
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE equipamentos_pecas
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE equipamentos
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.Sql(@"
                UPDATE categorias
                SET empresa_id = '00000000-0000-0000-0000-000000000000'
                WHERE empresa_id IS NULL;
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_empresas_empresa_id",
                table: "categorias",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_empresas_empresa_id",
                table: "equipamentos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_equipamentos_pecas_empresas_empresa_id",
                table: "equipamentos_pecas",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_especializacoes_empresas_empresa_id",
                table: "especializacoes",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ferramentas_empresas_empresa_id",
                table: "ferramentas",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_localizacoes_empresas_empresa_id",
                table: "localizacoes",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_manutencoes_empresas_empresa_id",
                table: "manutencoes",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_modelos_empresas_empresa_id",
                table: "modelos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ordens_servicos_empresas_empresa_id",
                table: "ordens_servicos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_papeis_empresas_empresa_id",
                table: "papeis",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_pecas_empresas_empresa_id",
                table: "pecas",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_pecas_usadas_empresas_empresa_id",
                table: "pecas_usadas",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_tecnicos_empresas_empresa_id",
                table: "tecnicos",
                column: "empresa_id",
                principalTable: "empresas",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_empresas_empresa_id",
                table: "categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_empresas_empresa_id",
                table: "equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_equipamentos_pecas_empresas_empresa_id",
                table: "equipamentos_pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_especializacoes_empresas_empresa_id",
                table: "especializacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ferramentas_empresas_empresa_id",
                table: "ferramentas");

            migrationBuilder.DropForeignKey(
                name: "FK_localizacoes_empresas_empresa_id",
                table: "localizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_manutencoes_empresas_empresa_id",
                table: "manutencoes");

            migrationBuilder.DropForeignKey(
                name: "FK_modelos_empresas_empresa_id",
                table: "modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_ordens_servicos_empresas_empresa_id",
                table: "ordens_servicos");

            migrationBuilder.DropForeignKey(
                name: "FK_papeis_empresas_empresa_id",
                table: "papeis");

            migrationBuilder.DropForeignKey(
                name: "FK_pecas_empresas_empresa_id",
                table: "pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_pecas_usadas_empresas_empresa_id",
                table: "pecas_usadas");

            migrationBuilder.DropForeignKey(
                name: "FK_tecnicos_empresas_empresa_id",
                table: "tecnicos");

            migrationBuilder.DropTable(
                name: "empresas");

            migrationBuilder.DropIndex(
                name: "IX_tecnicos_empresa_id",
                table: "tecnicos");

            migrationBuilder.DropIndex(
                name: "IX_pecas_usadas_empresa_id",
                table: "pecas_usadas");

            migrationBuilder.DropIndex(
                name: "IX_pecas_empresa_id",
                table: "pecas");

            migrationBuilder.DropIndex(
                name: "IX_papeis_empresa_id",
                table: "papeis");

            migrationBuilder.DropIndex(
                name: "IX_ordens_servicos_empresa_id",
                table: "ordens_servicos");

            migrationBuilder.DropIndex(
                name: "IX_modelos_empresa_id",
                table: "modelos");

            migrationBuilder.DropIndex(
                name: "IX_manutencoes_empresa_id",
                table: "manutencoes");

            migrationBuilder.DropIndex(
                name: "IX_localizacoes_empresa_id",
                table: "localizacoes");

            migrationBuilder.DropIndex(
                name: "IX_ferramentas_empresa_id",
                table: "ferramentas");

            migrationBuilder.DropIndex(
                name: "IX_especializacoes_empresa_id",
                table: "especializacoes");

            migrationBuilder.DropIndex(
                name: "IX_equipamentos_pecas_empresa_id",
                table: "equipamentos_pecas");

            migrationBuilder.DropIndex(
                name: "IX_equipamentos_empresa_id",
                table: "equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_categorias_empresa_id",
                table: "categorias");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "tecnicos");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "pecas_usadas");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "pecas");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "papeis");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "ordens_servicos");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "modelos");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "manutencoes");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "localizacoes");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "ferramentas");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "especializacoes");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "equipamentos_pecas");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "equipamentos");

            migrationBuilder.DropColumn(
                name: "empresa_id",
                table: "categorias");
        }
    }
}
