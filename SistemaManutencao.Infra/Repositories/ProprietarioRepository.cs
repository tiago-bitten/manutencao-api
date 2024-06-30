using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class ProprietarioRepository : BaseRepository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(SistemaManutencaoDbContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Proprietario?>> GetAllAsync()
        {
            return await _context.Set<Proprietario>()
                .Include(p => p.Empresas)
                .ToListAsync();
        }

        public async Task<Proprietario?> GetByCpfAsync(string cpf)
        {
            return await _context.Set<Proprietario>()
                .Include(p => p.Empresas)
                .FirstOrDefaultAsync(p => p.Cpf == cpf);
        }

        public async Task<Proprietario?> GetByEmailAsync(string email)
        {
            return await  _context.Set<Proprietario>()
                .Include(p => p.Empresas)
                .FirstOrDefaultAsync(p => p.Email.ToUpper() == email.ToUpper());
        }

        public override async Task<Proprietario?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Proprietario>()
                .Include(p => p.Empresas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
