using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class EquipamentoPecaConfig : IEntityTypeConfiguration<EquipamentoPeca>
    {
        public void Configure(EntityTypeBuilder<EquipamentoPeca> builder)
        {
            builder.ToTable("equipamentos_pecas");

            builder.HasKey(ep => new { ep.EquipamentoId, ep.PecaId });

            builder.Property(ep => ep.EquipamentoId)
                .HasColumnName("equipamento_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(ep => ep.PecaId)
                .HasColumnName("peca_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(ep => ep.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(ep => ep.Equipamento)
                .WithMany(e => e.EquipamentoPecas)
                .HasForeignKey(ep => ep.EquipamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ep => ep.Peca)
                .WithMany(p => p.EquipamentoPecas)
                .HasForeignKey(ep => ep.PecaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Empresa)
                .WithMany(ep => ep.EquipamentoPecas)
                .HasForeignKey(ep => ep.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
