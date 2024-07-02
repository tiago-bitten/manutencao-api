using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class GetEquipamentoById
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper _mapper;

        public GetEquipamentoById(IEquipamentoRepository equipamentoRepository, IEquipamentoService equipamentoService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _equipamentoService = equipamentoService;
            _mapper = mapper;
        }

        public async Task<GetEquipamentoDTO> ExecuteAsync(Guid id)
        {
            var equipamento = await _equipamentoService.ValidateEntityAsync(id);

            return _mapper.Map<GetEquipamentoDTO>(equipamento);
        }
    }
}
