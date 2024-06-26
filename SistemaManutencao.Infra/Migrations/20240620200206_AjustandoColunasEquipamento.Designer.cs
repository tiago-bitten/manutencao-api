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
    [Migration("20240620200206_AjustandoColunasEquipamento")]
    partial class AjustandoColunasEquipamento
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("categorias", (string)null);
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

                    b.Property<DateTime?>("DataAquisicao")
                        .HasColumnType("date")
                        .HasColumnName("data_aquisicao");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

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

                    b.Property<long?>("NumeroDeSerie")
                        .HasColumnType("bigint")
                        .HasColumnName("numero_de_serie");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("LocalizacaoId");

                    b.HasIndex("ModeloId");

                    b.ToTable("equipamentos", (string)null);
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("localizacoes", (string)null);
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("modelos", (string)null);
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Equipamento", b =>
                {
                    b.HasOne("SistemaManutencao.Domain.Entities.Categoria", "Categoria")
                        .WithMany("Equipamentos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SistemaManutencao.Domain.Entities.Localizacao", "Localizacao")
                        .WithMany("Equipamentos")
                        .HasForeignKey("LocalizacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SistemaManutencao.Domain.Entities.Modelo", "Modelo")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Categoria");

                    b.Navigation("Localizacao");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Localizacao", b =>
                {
                    b.Navigation("Equipamentos");
                });

            modelBuilder.Entity("SistemaManutencao.Domain.Entities.Modelo", b =>
                {
                    b.Navigation("Equipamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
