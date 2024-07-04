using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class TecnicoService : BaseService<Tecnico>, ITecnicoService
    {
        public TecnicoService(ITecnicoRepository repository)
            : base(repository)
        {
        }
    }
}
