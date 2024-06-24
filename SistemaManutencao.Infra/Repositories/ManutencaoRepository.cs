using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ManutencaoRepository : BaseRepository<Manutencao>, IManutencaoRepository
    {
        public ManutencaoRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
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
