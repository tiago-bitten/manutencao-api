using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class ProprietarioService : BaseService<Proprietario>, IProprietarioService
    {
        public ProprietarioService(IProprietarioRepository repository)
            : base(repository)
        {
        }
    }
}
