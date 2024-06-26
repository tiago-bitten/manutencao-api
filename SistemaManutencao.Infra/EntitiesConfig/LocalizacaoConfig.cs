using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class LocalizacaoConfig : IEntityTypeConfiguration<Localizacao>
    {
        void IEntityTypeConfiguration<Localizacao>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Localizacao> builder)
        {
            builder.ToTable("localizacoes");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(l => l.Nome)
                .HasDatabaseName("ix_localizacoes_nome");

            builder.Property(l => l.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(l => l.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasMany(l => l.Equipamentos)
                .WithOne(e => e.Localizacao)
                .HasForeignKey(e => e.LocalizacaoId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(l => l.Empresa)
                .WithMany(e => e.Localizacoes)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
