using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class EspecializacaoConfig : IEntityTypeConfiguration<Especializacao>
    {
        public void Configure(EntityTypeBuilder<Especializacao> builder)
        {
            builder.ToTable("especializacoes");

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
        
            builder.HasMany(e => e.Tecnicos)
                .WithOne(t => t.Especializacao)
                .HasForeignKey(t => t.EspecializacaoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
