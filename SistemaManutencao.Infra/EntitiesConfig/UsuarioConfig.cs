using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(u => u.SenhaHash)
                .HasColumnName("senha_hash")
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(u => u.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.Property(u => u.TipoUsuario)
                .HasColumnName("tipo_usuario")
                .HasColumnType("text")
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoUsuario)System.Enum.Parse(typeof(ETipoUsuario), v))
                .IsRequired();

            builder.Property(u => u.TecnicoId)
                .HasColumnName("tecnico_id")
                .HasColumnType("uuid");

            builder.HasOne(u => u.Tecnico)
                .WithOne(t => t.Usuario)
                .HasForeignKey<Usuario>(u => u.TecnicoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.EmpresaId)
                .HasColumnName("empresa_id")
                .HasColumnType("uuid")
                .IsRequired();
        }
    }
}
