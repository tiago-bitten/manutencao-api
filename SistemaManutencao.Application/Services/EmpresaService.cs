using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class EmpresaService : BaseService<Empresa>, IEmpresaService
    {
        public EmpresaService(IEmpresaRepository repository)
            : base(repository)
        {
        }
    }
}
