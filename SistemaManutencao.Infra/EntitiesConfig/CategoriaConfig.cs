using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categorias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(c => c.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(c => c.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.HasMany(c => c.Equipamentos)
                .WithOne(e => e.Categoria)
                .HasForeignKey(e => e.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.Empresa)
                .WithMany(e => e.Categorias)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(c => c.Nome)
                .HasDatabaseName("ix_categorias_nome");
        }
    }
}
