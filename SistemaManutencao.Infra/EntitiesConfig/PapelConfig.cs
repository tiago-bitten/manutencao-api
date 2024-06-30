using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class PapelConfig : IEntityTypeConfiguration<Papel>
    {
        public void Configure(EntityTypeBuilder<Papel> builder)
        {
            builder.ToTable("papeis");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(p => p.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.HasMany(p => p.OrdensServicos)
                .WithOne(os => os.Papel)
                .HasForeignKey(os => os.PapelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Empresa)
                .WithMany(e => e.Papeis)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(p => p.Nome)
                .HasDatabaseName("ix_papeis_nome");
        }
    }
}
