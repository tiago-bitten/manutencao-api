namespace SistemaManutencao.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<T> ValidarExistenciaAsync(Guid id);
    }
}
