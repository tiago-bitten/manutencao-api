namespace SistemaManutencao.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> ValidateEntityAsync(Guid id);
        Task<T> ValidateEntityByEmpresaIdAsync(Guid id, Guid empresaId);
    }
}
