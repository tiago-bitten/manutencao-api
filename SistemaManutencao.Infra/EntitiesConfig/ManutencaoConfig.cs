using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class ManutencaoConfig : IEntityTypeConfiguration<Manutencao>
    {
        public void Configure(EntityTypeBuilder<Manutencao> builder)
        {
            builder.ToTable("manutencoes");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(m => m.DataInicio)
                .HasColumnName("data_inicio")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(m => m.DataConclusao)
                .HasColumnName("data_conclusao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(m => m.Status)
                .HasColumnName("status")
                .HasColumnType("text")
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (EStatusManutencao)System.Enum.Parse(typeof(EStatusManutencao),v)
                 );

            builder.Property(m => m.TipoManutencao)
                .HasColumnName("tipo_manutencao")
                .HasColumnType("text")
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoManutencao)System.Enum.Parse(typeof(ETipoManutencao),v)
                );

            builder.Property(m => m.EquipamentoId)
                .HasColumnName("equipamento_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(m => m.Equipamento)
                .WithMany()
                .HasForeignKey(m => m.EquipamentoId)
                .HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
