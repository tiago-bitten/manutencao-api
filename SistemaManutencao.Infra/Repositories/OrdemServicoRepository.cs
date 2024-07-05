using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Contexts;

namespace SistemaManutencao.Infra.Data.Repositories
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>, IOrdemServicoRepository
    {
        public OrdemServicoRepository(SistemaManutencaoDbContext context)
            : base(context)
        {
        }

        public async override Task<IEnumerable<OrdemServico?>> GetAllByEmpresaIdAsync(Guid empresaId)
        {
            return await _context.Set<OrdemServico>()
                .Include(os => os.Manutencao)
                .Include(os => os.Tecnico)
                .Include(os => os.Papel)
                .Include(os => os.Empresa)
                .Where(os => os.EmpresaId == empresaId)
                .ToListAsync();
        }
    }
}
