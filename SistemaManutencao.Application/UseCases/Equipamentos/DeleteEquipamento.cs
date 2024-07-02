using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class DeleteEquipamento
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IEquipamentoService _equipamentoService;

        public DeleteEquipamento(IEquipamentoRepository equipamentoRepository, IEquipamentoService equipamentoService)
        {
            _equipamentoRepository = equipamentoRepository;
            _equipamentoService = equipamentoService;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var equipamento = await _equipamentoService.ValidateEntityAsync(id);

            await _equipamentoRepository.SoftRemoveAsync(equipamento.Id);
        }
    }
}
