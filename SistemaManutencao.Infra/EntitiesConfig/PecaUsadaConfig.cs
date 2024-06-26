using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class PecaUsadaConfig : IEntityTypeConfiguration<PecaUsada>
    {
        public void Configure(EntityTypeBuilder<PecaUsada> builder)
        {
            builder.ToTable("pecas_usadas");

            builder.HasKey(pu => new { pu.PecaId, pu.ManutencaoId });

            builder.Property(pu => pu.PecaId)
                .HasColumnName("peca_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(pu => pu.ManutencaoId)
                .HasColumnName("manutencao_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(pu => pu.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(pu => pu.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(pu => pu.Peca)
                .WithMany(p => p.PecasUsadas)
                .HasForeignKey(pu => pu.PecaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pu => pu.Manutencao)
                .WithMany(m => m.PecasUsadas)
                .HasForeignKey(pu => pu.ManutencaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pu => pu.Empresa)
                .WithMany(e => e.PecasUsadas)
                .HasForeignKey(pu => pu.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
