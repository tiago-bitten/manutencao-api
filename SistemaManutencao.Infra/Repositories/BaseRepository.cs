using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<IEnumerable<T?>> GetAllByEmpresaIdAsync(Guid empresaId)
        {
            return await _context.Set<T>()
                .Where(e => EF.Property<Guid>(e, "EmpresaId") == empresaId)
                .ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(IEnumerable<T?> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<T?> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public virtual async Task SoftRemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            _context.Entry(entity).Property("Ativo").CurrentValue = false;
            await _context.SaveChangesAsync();
        }
    }
}
