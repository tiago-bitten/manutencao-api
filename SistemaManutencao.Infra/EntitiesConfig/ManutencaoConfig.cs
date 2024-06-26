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

            builder.Property(m => m.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasIndex(m => m.Nome)
                .HasDatabaseName("idx_manutencoes_nome");

            builder.Property(m => m.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(m => m.DataInicio)
                .HasColumnName("data_inicio")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(m => m.DataConclusao)
                .HasColumnName("data_conclusao")
                .HasColumnType("date");

            builder.Property(m => m.Status)
                .HasColumnName("status")
                .HasColumnType("text")
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (EStatusManutencao)System.Enum.Parse(typeof(EStatusManutencao), v)
                 );

            builder.Property(m => m.TipoManutencao)
                .HasColumnName("tipo_manutencao")
                .HasColumnType("text")
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoManutencao)System.Enum.Parse(typeof(ETipoManutencao), v)
                );

            builder.Property(m => m.EquipamentoId)
                .HasColumnName("equipamento_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(m => m.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasOne(m => m.Equipamento)
                .WithMany(e => e.Manutencoes)
                .HasForeignKey(m => m.EquipamentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.OrdemServicos)
                .WithOne(os => os.Manutencao)
                .HasForeignKey(os => os.ManutencaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.PecasUsadas)
                .WithOne(pu => pu.Manutencao)
                .HasForeignKey(pu => pu.ManutencaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.Empresa)
                .WithMany(e => e.Manutencoes)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
