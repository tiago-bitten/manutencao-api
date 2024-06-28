using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    public partial class AdicionandoTipoUsuarioECheckConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tipo_usuario",
                table: "usuarios",
                type: "text",
                nullable: false,
                defaultValue: "Cliente");

            migrationBuilder.AddCheckConstraint(
                name: "CK_usuarios_tipo_usuario",
                table: "usuarios",
                sql: "tipo_usuario IN ('Funcionario', 'Cliente')");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION criar_tecnico_com_usuario(
                    p_nome VARCHAR(150),
                    p_telefone VARCHAR(15),
                    p_cpf VARCHAR(11),
                    p_possui_acesso BOOLEAN,
                    p_data_nascimento DATE,
                    p_especializacao_id UUID,
                    p_empresa_id UUID,
                    p_email VARCHAR(150),
                    p_senha_hash VARCHAR(1000)
                ) RETURNS UUID AS $$
                DECLARE
                    novo_tecnico_id UUID;
                    novo_usuario_id UUID;
                BEGIN
                    INSERT INTO tecnicos (id, nome, telefone, cpf, possui_acesso, data_nascimento, especializacao_id, empresa_id)
                    VALUES (uuid_generate_v4(), p_nome, p_telefone, p_cpf, p_possui_acesso, p_data_nascimento, p_especializacao_id, p_empresa_id)
                    RETURNING id INTO novo_tecnico_id;

                    IF p_possui_acesso THEN
                        INSERT INTO usuarios (id, email, senha_hash, ativo, tecnico_id, empresa_id, tipo_usuario)
                        VALUES (uuid_generate_v4(), p_email, p_senha_hash, true, novo_tecnico_id, p_empresa_id, 'Cliente')
                        RETURNING id INTO novo_usuario_id;
                    END IF;

                    RETURN novo_tecnico_id;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_usuarios_tipo_usuario",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "tipo_usuario",
                table: "usuarios");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION criar_tecnico_com_usuario(
                    p_nome VARCHAR(150),
                    p_telefone VARCHAR(15),
                    p_cpf VARCHAR(11),
                    p_possui_acesso BOOLEAN,
                    p_data_nascimento DATE,
                    p_especializacao_id UUID,
                    p_empresa_id UUID,
                    p_email VARCHAR(150),
                    p_senha_hash VARCHAR(1000)
                ) RETURNS UUID AS $$
                DECLARE
                    novo_tecnico_id UUID;
                    novo_usuario_id UUID;
                BEGIN
                    INSERT INTO tecnicos (id, nome, telefone, cpf, possui_acesso, data_nascimento, especializacao_id, empresa_id)
                    VALUES (uuid_generate_v4(), p_nome, p_telefone, p_cpf, p_possui_acesso, p_data_nascimento, p_especializacao_id, p_empresa_id)
                    RETURNING id INTO novo_tecnico_id;

                    IF p_possui_acesso THEN
                        INSERT INTO usuarios (id, email, senha_hash, ativo, tecnico_id, empresa_id)
                        VALUES (uuid_generate_v4(), p_email, p_senha_hash, true, novo_tecnico_id, p_empresa_id)
                        RETURNING id INTO novo_usuario_id;
                    END IF;

                    RETURN novo_tecnico_id;
                END;
                $$ LANGUAGE plpgsql;
            ");
        }
    }
}
