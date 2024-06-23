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

            builder.HasMany(t => t.OrdemServicos)
                .WithOne(os => os.Tecnico)
                .HasForeignKey(os => os.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
