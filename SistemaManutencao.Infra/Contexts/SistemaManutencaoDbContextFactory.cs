using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SistemaManutencao.Infra.Data.Contexts
{
    public class SistemaManutencaoDbContextFactory : IDesignTimeDbContextFactory<SistemaManutencaoDbContext>
    {
        public SistemaManutencaoDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../SistemaManutencao.API");

            if (!Directory.Exists(basePath))
            {
                throw new DirectoryNotFoundException($"Base path '{basePath}' not found.");
            }

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string 'DefaultConnection' not found.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<SistemaManutencaoDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new SistemaManutencaoDbContext(optionsBuilder.Options);
        }
    }
}
