using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class LocalizacaoService : BaseService<Localizacao>, ILocalizacaoService
    {
        public LocalizacaoService(ILocalizacaoRepository repository) 
            : base(repository)
        {
        }
    }
}
