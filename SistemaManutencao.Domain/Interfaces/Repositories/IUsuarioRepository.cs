using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
