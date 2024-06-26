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

            builder.Property(os => os.PapelId)
                .HasColumnName("papel_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(os => os.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(os => os.Manutencao)
                .WithMany(m => m.OrdemServicos)
                .HasForeignKey(os => os.ManutencaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.Tecnico)
                .WithMany(t => t.OrdensServicos)
                .HasForeignKey(os => os.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.Papel)
                .WithMany(p => p.OrdensServicos)
                .HasForeignKey(os => os.PapelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(os => os.Empresa)
                .WithMany(e => e.OrdensServicos)
                .HasForeignKey(os => os.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
