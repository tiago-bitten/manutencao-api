using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class GetEquipamentoById
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;
        public GetEquipamentoById(IEquipamentoRepository equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        public async Task<GetEquipamentoDTO> ExecuteAsync(Guid id)
        {
            var equipamento = _equipamentoRepository.GetByIdAsync(id);

            if (equipamento == null)
                throw new ArgumentException("Equipamento não encontrado");

            return _mapper.Map<GetEquipamentoDTO>(equipamento);
        }
    }
}
