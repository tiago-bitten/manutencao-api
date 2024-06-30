using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class EquipamentoConfig : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("equipamentos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(e => e.NumeroDeSerie)
                .HasColumnName("numero_de_serie")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.DataAquisicao)
                .HasColumnName("data_aquisicao")
                .HasColumnType("date");

            builder.Property(e => e.ModeloId)
                .HasColumnName("modelo_id")
                .HasColumnType("uuid");

            builder.Property(e => e.LocalizacaoId)
                .HasColumnName("localizacao_id")
                .HasColumnType("uuid");

            builder.Property(e => e.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("uuid");

            builder.Property(e => e.TotalManutencoesConcluidas)
                .HasColumnName("total_manutencoes_concluidas")
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(e => e.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(e => e.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.HasOne(e => e.Modelo)
                .WithMany(m => m.Equipamentos)
                .HasForeignKey(e => e.ModeloId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Localizacao)
                .WithMany()
                .HasForeignKey(e => e.LocalizacaoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.Categoria)
                .WithMany()
                .HasForeignKey(e => e.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.EquipamentoPecas)
                .WithOne(ep => ep.Equipamento)
                .HasForeignKey(ep => ep.EquipamentoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Manutencoes)
                .WithOne(m => m.Equipamento)
                .HasForeignKey(m => m.EquipamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Empresa)
                .WithMany(emp => emp.Equipamentos)
                .HasForeignKey(e => e.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
            
            builder.HasIndex(e => e.Nome)
                .HasDatabaseName("ix_equipamentos_nome");
        }
    }
}
