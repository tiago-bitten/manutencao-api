using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class ModeloConfig : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.ToTable("modelos");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(m => m.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(m => m.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.HasMany(m => m.Equipamentos)
                .WithOne(e => e.Modelo)
                .HasForeignKey(e => e.ModeloId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(m => m.Empresa)
                .WithMany(e => e.Modelos)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(m => m.Nome)
                .HasDatabaseName("ix_modelos_nome");
        }
    }
}
