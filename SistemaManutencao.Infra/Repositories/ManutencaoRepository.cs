using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;
using System.Runtime.CompilerServices;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ManutencaoRepository : BaseRepository<Manutencao>, IManutencaoRepository
    {
        public ManutencaoRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }

        public async override Task<IEnumerable<Manutencao?>> GetAllByEmpresaIdAsync(Guid empresaId)
        {
            return await _context.Set<Manutencao>()
                .Include(m => m.Equipamento)
                .Include(m => m.OrdemServicos)
                    .ThenInclude(os => os.Tecnico)
                .Include(m => m.OrdemServicos)
                    .ThenInclude(os => os.Papel)
                .Include(m => m.Empresa)
                .Where(m => m.EmpresaId == empresaId)
                .ToListAsync();

        }

        public async override Task<IEnumerable<Manutencao?>> GetAllAsync()
        {
            return await _context.Set<Manutencao>()
                .Include(m => m.Equipamento)
                .Include(m => m.OrdemServicos)
                    .ThenInclude(os => os.Tecnico)
                .Include(m => m.OrdemServicos)
                    .ThenInclude(os => os.Papel)
                .Include(m => m.Empresa)
                .ToListAsync();
        }

        public override void Update(Manutencao manutencao)
        {
            var existingManutencao = _context.Set<Manutencao>().Find(manutencao.Id);
            if (existingManutencao == null)
                throw new EntidadeNaoEncontradaException("EX10008", "Manutencao");

            _context.Entry(existingManutencao).CurrentValues.SetValues(manutencao);
            _context.Entry(existingManutencao).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries()
                     .Where(e => e.Entity is Manutencao && e.State == EntityState.Modified))
            {
                var entity = (Manutencao)entry.Entity;
            }

            _context.SaveChanges();
        }
    }
}
