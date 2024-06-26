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

            builder.HasIndex(m => m.Nome)
                .HasDatabaseName("ix_modelos_nome");

            builder.Property(m => m.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.HasMany(m => m.Equipamentos)
                .WithOne(e => e.Modelo)
                .HasForeignKey(e => e.ModeloId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
