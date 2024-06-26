using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class TecnicoConfig : IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            builder.ToTable("tecnicos");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(t => t.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.HasIndex(t => t.Nome)
                .HasDatabaseName("ix_tecnicos_nome");

            builder.Property(t => t.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(t => t.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(t => t.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("date")
                .IsRequired();

            builder.Property(t => t.EspecializacaoId)
                .HasColumnName("especializacao_id")
                .HasColumnType("uuid");

            builder.Property(t => t.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(t => t.PossuiAcesso)
                .HasColumnName("possui_acesso")
                .HasColumnType("boolean")
                .IsRequired();

            builder.HasMany(t => t.OrdensServicos)
                .WithOne(os => os.Tecnico)
                .HasForeignKey(os => os.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Especializacao)
                .WithMany(e => e.Tecnicos)
                .HasForeignKey(t => t.EspecializacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Empresa)
                .WithMany(e => e.Tecnicos)
                .HasForeignKey(t => t.EmpresaId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(t => t.Usuario)
                .WithOne(u => u.Tecnico)
                .HasForeignKey<Usuario>(u => u.TecnicoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
