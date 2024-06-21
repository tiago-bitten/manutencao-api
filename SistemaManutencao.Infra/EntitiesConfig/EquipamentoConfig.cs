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

            builder.HasOne(e => e.Modelo)
                .WithMany()
                .HasForeignKey(e => e.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Localizacao)
                .WithMany()
                .HasForeignKey(e => e.LocalizacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Categoria)
                .WithMany()
                .HasForeignKey(e => e.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.Manutencoes)
                .WithOne(m => m.Equipamento)
                .HasForeignKey(m => m.EquipamentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
