using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class GetAllEquipamentos
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;

        public GetAllEquipamentos(IEquipamentoRepository equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEquipamentoDTO>> ExecuteAsync()
        {
            var equipamentos = await _equipamentoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetEquipamentoDTO>>(equipamentos);
        }
    }
}
