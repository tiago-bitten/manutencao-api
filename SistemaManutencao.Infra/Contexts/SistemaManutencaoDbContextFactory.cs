using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace SistemaManutencao.Infra.Data.Contexts
{
    public class SistemaManutencaoDbContextFactory : IDesignTimeDbContextFactory<SistemaManutencaoDbContext>
    {
        public SistemaManutencaoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SistemaManutencaoDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);

            return new SistemaManutencaoDbContext(optionsBuilder.Options);
        }
    }
}
