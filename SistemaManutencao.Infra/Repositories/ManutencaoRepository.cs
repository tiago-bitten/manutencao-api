using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ManutencaoRepository : BaseRepository<Manutencao>, IManutencaoRepository
    {
        public ManutencaoRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }
    }
}
