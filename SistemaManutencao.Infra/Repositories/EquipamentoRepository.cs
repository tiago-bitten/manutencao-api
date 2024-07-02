using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
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

        public override async Task<IEnumerable<Equipamento?>> GetAllAsync()
        {
            return await _context.Set<Equipamento>()
                .Include(e => e.Categoria)
                .Include(e => e.Modelo)
                .Include(e => e.Localizacao)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Equipamento?>> GetAllByEmpresaIdAsync(Guid empresaId)
        {
            return await _context.Set<Equipamento>()
                .Include(e => e.Categoria)
                .Include(e => e.Modelo)
                .Include(e => e.Localizacao)
                .Where(e => e.Empresa.Id == empresaId)
                .ToListAsync();
        }

        public override void Update(Equipamento entity)
        {
            var existingEquipamento = _context.Set<Equipamento>().Find(entity.Id);
            if (existingEquipamento == null)
                throw new EntidadeNaoEncontradaException("EX10008", "Equipamento");

            _context.Entry(existingEquipamento).CurrentValues.SetValues(entity);
            _context.Entry(existingEquipamento).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries()
                                    .Where(e => e.Entity is Equipamento && e.State == EntityState.Modified))
            {
                var equipamento = (Equipamento)entry.Entity;
            }

            _context.SaveChanges();
        }
    }
}
