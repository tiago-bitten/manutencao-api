using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class CadastroItemGeralRepository : BaseRepository<CadastroGeralItem>, ICadastroGeralItemRepository
    {
        public CadastroItemGeralRepository(SistemaManutencaoDbContext context) : base(context)
        {
        }
    }
}
