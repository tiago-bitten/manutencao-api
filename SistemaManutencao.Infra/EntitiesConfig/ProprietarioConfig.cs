using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class ProprietarioConfig : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("proprietarios");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("UUID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(150)")
                .IsRequired();

            builder.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasColumnType("VARCHAR(11)")
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("VARCHAR(11)")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("BOOLEAN")
                .HasDefaultValue(true);

            builder.HasMany(p => p.Empresas)
                .WithOne(e => e.Proprietario)
                .HasForeignKey(e => e.ProprietarioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
