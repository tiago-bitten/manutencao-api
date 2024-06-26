using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class EspecializacaoRepository : BaseRepository<Especializacao>, IEspecializacaoRepository
    {
        public EspecializacaoRepository(SistemaManutencaoDbContext context)
            : base(context)
        {
        }
    }
}
