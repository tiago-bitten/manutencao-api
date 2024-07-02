using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class DeleteCategoria
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;

        public DeleteCategoria(ICategoriaRepository categoriaRepository, ICategoriaService categoriaService)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var categoria = await _categoriaService.ValidateEntityAsync(id);

            await _categoriaRepository.SoftRemoveAsync(categoria.Id);
        }
    }
}
