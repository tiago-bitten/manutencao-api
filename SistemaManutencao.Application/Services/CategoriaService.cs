using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.Services
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) 
            : base(repository)
        {
        }
    }
}
