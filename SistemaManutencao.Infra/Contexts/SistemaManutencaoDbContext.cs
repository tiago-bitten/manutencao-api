using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Infra.Data.EntitiesConfig;

namespace SistemaManutencao.Infra.Data.Contexts
{
    public class SistemaManutencaoDbContext : DbContext
    {
        public SistemaManutencaoDbContext(DbContextOptions<SistemaManutencaoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EquipamentoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new LocalizacaoConfig());
            modelBuilder.ApplyConfiguration(new ModeloConfig());
        }
    }
}
