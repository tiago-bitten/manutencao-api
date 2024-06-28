using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.CpfCnpj)
                .HasColumnName("cpf_cnpj")
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.TipoEmpresa)
                .HasColumnName("tipo_empresa")
                .HasColumnType("text")
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoEmpresa)System.Enum.Parse(typeof(ETipoEmpresa), v))
                .IsRequired();

            builder.Property(e => e.Telefone)
                .HasColumnName("telefone")
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(2)");

            builder.Property(e => e.Cep)
                .HasColumnName("cep")
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Ativo)
                .HasColumnName("ativo")
                .HasColumnType("boolean")
                .HasDefaultValue(true);

            builder.Property(e => e.ProprietarioId)
                .HasColumnName("proprietario_id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.HasIndex(e => e.CpfCnpj)
                .IsUnique()
                .HasDatabaseName("ix_empresas_cpf_cnpj");

            builder.HasIndex(e => e.Email)
                .IsUnique()
                .HasDatabaseName("ix_empresas_email");

            builder.HasIndex(e => e.Nome)
                .HasDatabaseName("ix_empresas_nome");

            builder.HasOne(e => e.Proprietario)
                .WithOne(p => p.Empresa)
                .HasForeignKey<Empresa>(e => e.ProprietarioId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.Categorias)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Equipamentos)
                .WithOne(eq => eq.Empresa)
                .HasForeignKey(eq => eq.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.EquipamentoPecas)
                .WithOne(ep => ep.Empresa)
                .HasForeignKey(ep => ep.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Especializacoes)
                .WithOne(es => es.Empresa)
                .HasForeignKey(es => es.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Ferramentas)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Localizacoes)
                .WithOne(l => l.Empresa)
                .HasForeignKey(l => l.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Manutencoes)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Modelos)
                .WithOne(m => m.Empresa)
                .HasForeignKey(m => m.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.OrdensServicos)
                .WithOne(os => os.Empresa)
                .HasForeignKey(os => os.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Pecas)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Papeis)
                .WithOne(p => p.Empresa)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.PecasUsadas)
                .WithOne(pu => pu.Empresa)
                .HasForeignKey(pu => pu.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Tecnicos)
                .WithOne(t => t.Empresa)
                .HasForeignKey(t => t.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Usuarios)
                .WithOne(u => u.Empresa)
                .HasForeignKey(u => u.EmpresaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
