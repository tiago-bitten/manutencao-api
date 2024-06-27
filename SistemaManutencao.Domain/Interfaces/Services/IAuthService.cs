using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateTokenAsync(Usuario usuario);
        bool ValidateToken(string token);
    }
}
