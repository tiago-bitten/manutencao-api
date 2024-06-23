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

            builder.HasMany(p => p.OrdensServicos)
                .WithOne(os => os.Papel)
                .HasForeignKey(os => os.PapelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
