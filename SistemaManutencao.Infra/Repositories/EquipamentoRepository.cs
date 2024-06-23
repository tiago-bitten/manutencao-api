using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(SistemaManutencaoDbContext context) : base(context)
        {
        }

        public override async Task<Equipamento?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Equipamento>()
                .Include(e => e.Categoria)
                .Include(e => e.Modelo)
                .Include(e => e.Localizacao)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task<IEnumerable<Equipamento>> GetAllAsync()
        {
            return await _context.Set<Equipamento>()
                .Include(e => e.Categoria)
                .Include(e => e.Modelo)
                .Include(e => e.Localizacao)
                .ToListAsync();
        }
    }
}
