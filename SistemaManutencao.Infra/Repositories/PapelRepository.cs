using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class PapelRepository : BaseRepository<Papel>, IPapelRepository
    {
        public PapelRepository(SistemaManutencaoDbContext context)
            : base(context)
        {
        }
    }
}
