using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class PecaConfig : IEntityTypeConfiguration<Peca>
    {
        public void Configure(EntityTypeBuilder<Peca> builder)
        {
            builder.ToTable("pecas");

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

            builder.HasMany(p => p.EquipamentoPecas)
                .WithOne(ep => ep.Peca)
                .HasForeignKey(ep => ep.PecaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
