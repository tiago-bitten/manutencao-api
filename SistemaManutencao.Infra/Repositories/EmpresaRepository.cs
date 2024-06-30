using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }

        public override async Task<IEnumerable<Empresa?>> GetAllAsync()
        {
            return await _context.Set<Empresa>()
                .Include(e => e.Proprietario)
                .ToListAsync();
        }

        public override async Task<Empresa?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Empresa>()
                .Include(e => e.Proprietario)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
