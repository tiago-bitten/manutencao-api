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

            builder.Property(l => l.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.HasMany(l => l.CadastroGeralItems)
                .WithOne(c => c.Localizacao)
                .HasForeignKey(c => c.LocalizacaoId);
        }
    }
}
