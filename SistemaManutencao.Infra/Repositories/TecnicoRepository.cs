using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class TecnicoRepository : BaseRepository<Tecnico>, ITecnicoRepository
    {
        public TecnicoRepository(SistemaManutencaoDbContext context) 
            : base(context)
        { 
        }
    }
}
