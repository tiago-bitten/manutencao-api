using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
    {
        public ModeloRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }
    }
}
