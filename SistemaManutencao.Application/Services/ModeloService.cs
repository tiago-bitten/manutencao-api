using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class ModeloService : BaseService<Modelo>, IModeloService
    {
        public ModeloService(IModeloRepository repository) 
            : base(repository)
        {
        }
    }
}
