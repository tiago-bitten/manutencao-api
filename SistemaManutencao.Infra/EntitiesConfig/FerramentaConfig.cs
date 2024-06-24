using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public sealed class FerramentaConfig : IEntityTypeConfiguration<Ferramenta>
    {
        public void Configure(EntityTypeBuilder<Ferramenta> builder)
        {
            builder.ToTable("ferramentas");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasIndex(f => f.Nome)
                .HasDatabaseName("ix_ferramentas_nome");

            builder.Property(f => f.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");
        }
    }
}
