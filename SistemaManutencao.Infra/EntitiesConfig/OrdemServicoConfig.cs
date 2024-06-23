using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class OrdemServicoConfig : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("ordens_servicos");

            builder.HasKey(os => new { os.ManutencaoId, os.TecnicoId });

            builder.Property(os => os.ManutencaoId)
                .HasColumnName("manutencao_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(os => os.TecnicoId)
                .HasColumnName("tecnico_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(os => os.Manutencao)
                .WithMany(m => m.OrdemServicos)
                .HasForeignKey(os => os.ManutencaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.Tecnico)
                .WithMany(t => t.OrdemServicos)
                .HasForeignKey(os => os.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
