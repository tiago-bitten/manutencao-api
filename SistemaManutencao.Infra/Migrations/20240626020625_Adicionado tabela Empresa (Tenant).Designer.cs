﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaManutencao.Infra.Data.Contexts;

#nullable disable

namespace SistemaManutencao.Infra.Data.Migrations
{
    [DbContext(typeof(SistemaManutencaoDbContext))]
    [Migration("20240626020625_Adicionado tabela Empresa (Tenant)")]
    partial class AdicionadotabelaEmpresaTenant
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_categorias_nome");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool?>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("ativo");

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(8)")
                        .HasColumnName("cep");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cidade");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("cpf_cnpj");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(150)")
                        .HasColumnName("endereco");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(2)")
                        .HasColumnName("estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20)")
                        .HasColumnName("telefone");

                    b.Property<string>("TipoEmpresa")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tipo_empresa");

                    b.HasKey("Id");

                    b.HasIndex("CpfCnpj")
                        .IsUnique()
                        .HasDatabaseName("ix_empresas_cpf_cnpj");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_empresas_email");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_empresas_nome");

                    b.ToTable("empresas", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Equipamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("uuid")
                        .HasColumnName("categoria_id");

                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime?>("DataAquisicao")
                        .HasColumnType("date")
                        .HasColumnName("data_aquisicao");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<Guid?>("LocalizacaoId")
                        .HasColumnType("uuid")
                        .HasColumnName("localizacao_id");

                    b.Property<Guid?>("ModeloId")
                        .HasColumnType("uuid")
                        .HasColumnName("modelo_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("NumeroDeSerie")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("numero_de_serie");

                    b.Property<int>("TotalManutencoesConcluidas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("total_manutencoes_concluidas");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_equipamentos_nome");

                    b.ToTable("equipamentos", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.EquipamentoPeca", b =>
                {
                    b.Property<Guid>("EquipamentoId")
                        .HasColumnType("uuid")
                        .HasColumnName("equipamento_id");

                    b.Property<Guid>("PecaId")
                        .HasColumnType("uuid")
                        .HasColumnName("peca_id");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.HasKey("EquipamentoId", "PecaId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PecaId");

                    b.ToTable("equipamentos_pecas", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Especializacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_especializacoes_nome");

                    b.ToTable("especializacoes", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Ferramenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_ferramentas_nome");

                    b.ToTable("ferramentas", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Localizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_localizacoes_nome");

                    b.ToTable("localizacoes", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Manutencao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("date")
                        .HasColumnName("data_conclusao");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("date")
                        .HasColumnName("data_inicio");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<Guid>("EquipamentoId")
                        .HasColumnType("uuid")
                        .HasColumnName("equipamento_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<string>("TipoManutencao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tipo_manutencao");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("idx_manutencoes_nome");

                    b.ToTable("manutencoes", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Modelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_modelos_nome");

                    b.ToTable("modelos", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.OrdemServico", b =>
                {
                    b.Property<Guid>("ManutencaoId")
                        .HasColumnType("uuid")
                        .HasColumnName("manutencao_id");

                    b.Property<Guid>("TecnicoId")
                        .HasColumnType("uuid")
                        .HasColumnName("tecnico_id");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<Guid>("PapelId")
                        .HasColumnType("uuid")
                        .HasColumnName("papel_id");

                    b.HasKey("ManutencaoId", "TecnicoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PapelId");

                    b.HasIndex("TecnicoId");

                    b.ToTable("ordens_servicos", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_papeis_nome");

                    b.ToTable("papeis", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Peca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_pecas_nome");

                    b.ToTable("pecas", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.PecaUsada", b =>
                {
                    b.Property<Guid>("PecaId")
                        .HasColumnType("uuid")
                        .HasColumnName("peca_id");

                    b.Property<Guid>("ManutencaoId")
                        .HasColumnType("uuid")
                        .HasColumnName("manutencao_id");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("PecaId", "ManutencaoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("ManutencaoId");

                    b.ToTable("pecas_usadas", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Tecnico", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date")
                        .HasColumnName("data_nascimento");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnType("uuid")
                        .HasColumnName("empresa_id");

                    b.Property<Guid?>("EspecializacaoId")
                        .HasColumnType("uuid")
                        .HasColumnName("especializacao_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefone");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EspecializacaoId");

                    b.HasIndex("Nome")
                        .HasDatabaseName("ix_tecnicos_nome");

                    b.ToTable("tecnicos", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Categoria", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Categorias")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Equipamento", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Equipamentos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Equipamentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Localizacao", "Localizacao")
                        .WithMany("Equipamentos")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SistemaManutencao.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Categoria");

                    b.Navigation("Empresa");

                    b.Navigation("Localizacao");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.EquipamentoPeca", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("EquipamentoPecas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("EquipamentoPecas")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Peca", "Peca")
                        .WithMany("EquipamentoPecas")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Equipamento");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Especializacao", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Especializacoes")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Ferramenta", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Ferramentas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Localizacao", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Localizacoes")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Manutencao", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Manutencoes")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Equipamento", "Equipamento")
                        .WithMany("Manutencoes")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Modelo", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Modelos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.OrdemServico", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Manutencao", "Manutencao")
                        .WithMany("OrdemServicos")
                        .HasForeignKey("ManutencaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Papel", "Papel")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("PapelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Tecnico", "Tecnico")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("TecnicoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Manutencao");

                    b.Navigation("Papel");

                    b.Navigation("Tecnico");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Papel", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Papeis")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Peca", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Pecas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.PecaUsada", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("PecasUsadas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Manutencao", "Manutencao")
                        .WithMany("PecasUsadas")
                        .HasForeignKey("ManutencaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Peca", "Peca")
                        .WithMany("PecasUsadas")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Manutencao");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Tecnico", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Tecnicos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("SistemaManutencao.Domain.Entities.Especializacao", "Especializacao")
                        .WithMany("Tecnicos")
                        .HasForeignKey("EspecializacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Empresa");

                    b.Navigation("Especializacao");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("EquipamentoPecas");

                    b.Navigation("Equipamentos");

                    b.Navigation("Especializacoes");

                    b.Navigation("Ferramentas");

                    b.Navigation("Localizacoes");

                    b.Navigation("Manutencoes");

                    b.Navigation("Modelos");

                    b.Navigation("OrdensServicos");

                    b.Navigation("Papeis");

                    b.Navigation("Pecas");

                    b.Navigation("PecasUsadas");

                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Equipamento", b =>
                {
                    b.Navigation("EquipamentoPecas");

                    b.Navigation("Manutencoes");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Especializacao", b =>
                {
                    b.Navigation("Tecnicos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Localizacao", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Manutencao", b =>
                {
                    b.Navigation("OrdemServicos");

                    b.Navigation("PecasUsadas");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Papel", b =>
                {
                    b.Navigation("OrdensServicos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Peca", b =>
                {
                    b.Navigation("EquipamentoPecas");

                    b.Navigation("PecasUsadas");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Tecnico", b =>
                {
                    b.Navigation("OrdensServicos");
                });
#pragma warning restore 612, 618
        }
    }
}
