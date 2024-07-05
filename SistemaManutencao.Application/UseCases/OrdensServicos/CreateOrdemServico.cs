using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.OrdensServicos;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System.Runtime.CompilerServices;

namespace SistemaManutencao.Application.UseCases.OrdensServicos
{
    public class CreateOrdemServico
    {
        private readonly IOrdemServicoRepository _ordemServicoRepository;
        private readonly IManutencaoRepository _manutencaoRepository;
        private readonly IAuthService _authService;
        private readonly IManutencaoService _manutencaoService;
        private readonly ITecnicoService _tecnicoService;
        private readonly IPapelService _papelService;
        private readonly IMapper _mapper;

        public CreateOrdemServico(IManutencaoRepository manutencaoRepository, IOrdemServicoRepository ordemServicoRepository, IAuthService authService, IManutencaoService manutencaoService, ITecnicoService tecnicoService, IPapelService papelService, IMapper mapper)
        {
            _manutencaoRepository = manutencaoRepository;
            _ordemServicoRepository = ordemServicoRepository;
            _authService = authService;
            _manutencaoService = manutencaoService;
            _tecnicoService = tecnicoService;
            _papelService = papelService;
            _mapper = mapper;
        }

        public async Task<GetOrdemServicoDTO> ExecuteAsync(CreateOrdemServicoDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);
            var manutencao = await _manutencaoService.ValidateEntityByEmpresaIdAsync(dto.ManutencaoId, empresaId);
            var tecnico = await _tecnicoService.ValidateEntityByEmpresaIdAsync(dto.TecnicoId, empresaId);
            var papel = await _papelService.ValidateEntityByEmpresaIdAsync(dto.PapelId, empresaId);

            var ordemServico = _mapper.Map<OrdemServico>(dto);

            SetOrdemServicoProperties(ordemServico, empresaId, manutencao, tecnico, papel);

            await _ordemServicoRepository.AddAsync(ordemServico);

            return _mapper.Map<GetOrdemServicoDTO>(ordemServico);
        }

        private void SetOrdemServicoProperties(OrdemServico ordemServico, Guid empresaId, Manutencao manutencao, Tecnico tecnico, Papel papel)
        {
            ordemServico.EmpresaId = empresaId;
            ordemServico.Manutencao = manutencao;
            ordemServico.Tecnico = tecnico;
            ordemServico.Papel = papel;
        }
    }
}
