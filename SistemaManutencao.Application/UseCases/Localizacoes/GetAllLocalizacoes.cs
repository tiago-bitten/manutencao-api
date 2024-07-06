using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class GetAllLocalizacoes
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IAuthService _authService;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IMapper _mapper;

        public GetAllLocalizacoes(IQueryFilterService queryFilterService, ILocalizacaoRepository localizacaoRepository, IAuthService authService, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _queryFilterService = queryFilterService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetLocalizacaoDTO>> ExecuteAsync(Filtro filtros, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var localizacoes = await _localizacaoRepository.GetAllByEmpresaIdAsync(empresaId);

            var localizacoesFiltradas = _queryFilterService.AplicarTodosOsFiltros(localizacoes.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetLocalizacaoDTO>>(localizacoesFiltradas.ToList());
        }
    }
}
