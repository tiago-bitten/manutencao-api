using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Repositories
{
    public interface ITecnicoRepository : IBaseRepository<Tecnico>
    {
        Task<Tecnico?> CreateTecnicoComAcessoAsync(Tecnico tecnico, string email, string senhaHas);
    }
}
