using SistemaManutencao.Domain.Entities;
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
    }
}
