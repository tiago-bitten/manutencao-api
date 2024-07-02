using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Manutencoes
{
    public class CreateManutencao
    {
        private readonly IManutencaoRepository _manutencaoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IEquipamentoService _equipamentoService;

        public CreateManutencao(IManutencaoRepository manutencaoRepository, IAuthService authService, IMapper mapper, IEquipamentoService equipamentoService)
        {
            _manutencaoRepository = manutencaoRepository;
            _authService = authService;
            _mapper = mapper;
            _equipamentoService = equipamentoService;
        }

        public async Task<GetManutencaoDTO> ExecuteAsync(CreateManutencaoDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var equipamento = await _equipamentoService.ValidateEntityByEmpresaIdAsync(dto.EquipamentoId, empresaId);

            if (dto.DataConclusao.HasValue && dto.DataConclusao.Value < dto.DataInicio)
                throw new RegraNegocioException("Ex10020", "Data de conclusão não pode ser anterior a data de início");

            if (dto.Status == EStatusManutencao.Concluido && !dto.DataConclusao.HasValue)
                throw new RegraNegocioException("Ex10021", "Data de conclusão é obrigatoria para manutenções concluidas");

            if (dto.Status != EStatusManutencao.Concluido && dto.DataConclusao.HasValue)
                throw new RegraNegocioException("Ex10022", "Data de conclusão não pode ser informada para manutenções não concluidas");

            var manutencao = _mapper.Map<Manutencao>(dto);

            manutencao.Equipamento = equipamento;
            manutencao.EmpresaId = empresaId;

            await _manutencaoRepository.AddAsync(manutencao);

            return _mapper.Map<GetManutencaoDTO>(manutencao);
        }
    }
}
