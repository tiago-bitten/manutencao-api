using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.DapperRepositories
{
    public interface ITecnicoDapperRepository
    {
        Task<Tecnico> CreateTecnicoComAcessoAsync(Tecnico tecnico, string email, string senhaHash);
    }
}
