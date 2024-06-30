using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Repositories
{
    public interface IProprietarioRepository : IBaseRepository<Proprietario>
    {
        Task<Proprietario?> GetByEmailAsync(string email);
        Task<Proprietario?> GetByCpfAsync(string cpf);
    }
}
