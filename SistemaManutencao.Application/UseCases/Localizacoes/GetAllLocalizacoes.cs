using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class GetAllLocalizacoes
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllLocalizacoes(ILocalizacaoRepository localizacaoRepository, IAuthService authService, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetLocalizacaoDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var localizacoes = await _localizacaoRepository.GetAllByEmpresaIdAsync(empresaId);

            if (!string.IsNullOrEmpty(nome))
                localizacoes = localizacoes.Where(l => l.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetLocalizacaoDTO>>(localizacoes);
        }
    }
}
