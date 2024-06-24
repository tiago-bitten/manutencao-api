using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ModeloRepository : BaseRepository<Modelo>, IModeloRepository
    {
        public ModeloRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }

        public override void Update(Modelo entity)
        {
            var existingModelo = _context.Set<Modelo>().Find(entity.Id);
            if (existingModelo == null)
                throw new EntidadeNaoEncontradaException("EX10008", "Modelo");

            _context.Entry(existingModelo).CurrentValues.SetValues(entity);
            _context.Entry(existingModelo).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries()
                                               .Where(e => e.Entity is Modelo && e.State == EntityState.Modified))
            {
                var modelo = (Modelo)entry.Entity;
            }

            _context.SaveChanges();
        }
    }
}
