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

            builder.Property(f => f.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(f => f.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(f => f.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.HasOne(f => f.Empresa)
                .WithMany(e => e.Ferramentas)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(f => f.Nome)
                .HasDatabaseName("ix_ferramentas_nome");
        }
    }
}
