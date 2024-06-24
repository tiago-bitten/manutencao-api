using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(SistemaManutencaoDbContext context) : base(context)
        {
        }

        public override void Update(Categoria entity)
        {
            var existingCategoria = _context.Set<Categoria>().Find(entity.Id);
            if (existingCategoria == null)
                throw new EntidadeNaoEncontradaException("EX10008", "Categoria");

            _context.Entry(existingCategoria).CurrentValues.SetValues(entity);
            _context.Entry(existingCategoria).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries()
                                                   .Where(e => e.Entity is Categoria && e.State == EntityState.Modified))
            {
                var categoria = (Categoria)entry.Entity;
            }

            _context.SaveChanges();
        }
    }
}
