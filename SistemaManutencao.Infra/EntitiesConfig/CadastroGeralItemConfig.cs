using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Infra.Data.EntitiesConfig
{
    public class CadastroGeralItemConfig : IEntityTypeConfiguration<CadastroGeralItem>
    {
        public void Configure(EntityTypeBuilder<CadastroGeralItem> builder)
        {
            builder.ToTable("cadastro_geral_itens");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnName("descricao")
                .HasColumnType("text");

            builder.Property(n => n.NumeroDeSerie)
                .HasColumnName("numero_serie")
                .HasColumnType("bigint");

            builder.Property(n => n.Quantidade)
                .HasColumnName("quantidade")
                .HasColumnType("int");

            builder.Property(n => n.TipoItem)
                .HasColumnName("tipo_item")
                .HasColumnType("varchar(20)")
                .HasConversion(
                    v => v.ToString(),
                    v => (ETipoItem)Enum.Parse(typeof(ETipoItem), v))
                .IsRequired();

            builder.Property(n => n.DataAquisicao)
                .HasColumnName("data_aquisicao")
                .HasColumnType("date");

            builder.Property(c => c.CategoriaId)
                .HasColumnName("categoria_id")
                .HasColumnType("uuid");

            builder.Property(c => c.ModeloId)
                .HasColumnName("modelo_id")
                .HasColumnType("uuid");

            builder.Property(c => c.LocalizacaoId)
                .HasColumnName("localizacao_id")
                .HasColumnType("uuid");

            builder.HasOne(c => c.Categoria)
                .WithMany(c => c.CadastroGeralItems)
                .HasForeignKey(c => c.CategoriaId);

            builder.HasOne(c => c.Modelo)
                .WithMany(c => c.CadastroGeralItems)
                .HasForeignKey(c => c.ModeloId);
            
            builder.HasOne(c => c.Localizacao)
                .WithMany(c => c.CadastroGeralItems)
                .HasForeignKey(c => c.LocalizacaoId);
        }
    }
}
