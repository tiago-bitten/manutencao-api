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

        public DbSet<Manutencao> Manutencaos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<EquipamentoPeca> EquipamentoPecas { get; set; }
        public DbSet<Ferramenta> Ferramentas { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<OrdemServico> OrdensServicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManutencaoConfig());
            modelBuilder.ApplyConfiguration(new EquipamentoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new LocalizacaoConfig());
            modelBuilder.ApplyConfiguration(new ModeloConfig());
            modelBuilder.ApplyConfiguration(new PecaConfig());
            modelBuilder.ApplyConfiguration(new EquiapmentoPecaConfig());
            modelBuilder.ApplyConfiguration(new FerramentaConfig());
            modelBuilder.ApplyConfiguration(new TecnicoConfig());
            modelBuilder.ApplyConfiguration(new OrdemServicoConfig());
        }
    }
}
