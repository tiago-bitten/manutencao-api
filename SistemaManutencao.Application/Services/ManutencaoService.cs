using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class ManutencaoService : BaseService<Manutencao>, IManutencaoService
    {
        public ManutencaoService(IManutencaoRepository repository)
            : base(repository)
        {
        }
    }
}
