using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class LocalizacaoRepository : BaseRepository<Localizacao>, ILocalizacaoRepository
    {
        public LocalizacaoRepository(SistemaManutencaoDbContext context) 
            : base(context) 
        { 
        }

        public override void Update(Localizacao entity)
        {
            var existingLocalizacao = _context.Set<Localizacao>().Find(entity.Id);
            if (existingLocalizacao == null)
                throw new EntidadeNaoEncontradaException("EX10008", $"{entity.Id}");

            _context.Entry(existingLocalizacao).CurrentValues.SetValues(entity);
            _context.Entry(existingLocalizacao).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries()
                                .Where(e => e.Entity is Localizacao && e.State == EntityState.Modified))
            {
                var localizacao = (Localizacao)entry.Entity;
            }

            _context.SaveChanges();
        }
    }
}
