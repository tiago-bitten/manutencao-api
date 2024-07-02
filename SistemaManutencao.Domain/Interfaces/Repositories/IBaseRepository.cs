namespace SistemaManutencao.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T?>> GetAllAsync();
        Task<IEnumerable<T?>> GetAllByEmpresaIdAsync(Guid empresaId);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T?> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T?> entities);
        Task SoftRemoveAsync(Guid id);
    }
}
