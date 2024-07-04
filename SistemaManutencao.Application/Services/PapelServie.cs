using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class PapelService : BaseService<Papel>, IPapelService
    {
        public PapelService(IPapelRepository repository)
            : base(repository)
        {
        }
    }
}
