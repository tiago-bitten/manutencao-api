using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class EquipamentoService : BaseService<Equipamento>, IEquipamentoService
    {
        public EquipamentoService(IEquipamentoRepository repository)
            : base(repository)
        {
        }
    }
}
