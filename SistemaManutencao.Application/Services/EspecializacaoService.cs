using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class EspecializacaoService : BaseService<Especializacao>, IEspecializacaoService
    {
        public EspecializacaoService(IEspecializacaoRepository repository) 
            : base(repository)
        {
        }
    }
}
