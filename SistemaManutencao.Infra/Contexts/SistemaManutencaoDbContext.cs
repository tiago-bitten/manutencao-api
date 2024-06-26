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

        public DbSet<Empresa> Empresas { get; set; }
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
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<PecaUsada> PecasUsadas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new ManutencaoConfig());
            modelBuilder.ApplyConfiguration(new EquipamentoConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new LocalizacaoConfig());
            modelBuilder.ApplyConfiguration(new ModeloConfig());
            modelBuilder.ApplyConfiguration(new PecaConfig());
            modelBuilder.ApplyConfiguration(new EquipamentoPecaConfig());
            modelBuilder.ApplyConfiguration(new FerramentaConfig());
            modelBuilder.ApplyConfiguration(new TecnicoConfig());
            modelBuilder.ApplyConfiguration(new OrdemServicoConfig());
            modelBuilder.ApplyConfiguration(new PapelConfig());
            modelBuilder.ApplyConfiguration(new EspecializacaoConfig());
            modelBuilder.ApplyConfiguration(new PecaUsadaConfig());
        }
    }
}
