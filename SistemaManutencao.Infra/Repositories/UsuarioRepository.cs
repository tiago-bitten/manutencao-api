using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SistemaManutencaoDbContext context) 
            : base(context)
        {
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Set<Usuario>()
                .FirstOrDefaultAsync(u => 
                    u.Email.ToUpper().Equals(email.ToUpper()));
        }
    }
}
