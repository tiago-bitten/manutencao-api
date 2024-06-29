using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateTokenAsync(Usuario usuario);
        bool ValidateToken(string token);
        string ResolveToken(string token);
        Guid GetUserId(string token);
        Guid GetEmpresaId(string token);
    }
}
