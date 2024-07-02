using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class CreateLocalizacao
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateLocalizacao(ILocalizacaoRepository localizacaoRepository, IMapper mapper, IAuthService authService)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<GetLocalizacaoDTO> ExecuteAsync(CreateLocalizacaoDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var localizacao = _mapper.Map<Localizacao>(dto);

            localizacao.EmpresaId = empresaId;

            await _localizacaoRepository.AddAsync(localizacao);

            return _mapper.Map<GetLocalizacaoDTO>(localizacao);
        }
    }
}
