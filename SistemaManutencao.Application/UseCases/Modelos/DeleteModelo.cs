using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class DeleteModelo
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IModeloService _modeloService;

        public DeleteModelo(IModeloRepository modeloRepository, IModeloService modeloService)
        {
            _modeloRepository = modeloRepository;
            _modeloService = modeloService;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var modelo = await _modeloService.ValidateEntityAsync(id);

            await _modeloRepository.SoftRemoveAsync(modelo.Id);
        }
    }
}
