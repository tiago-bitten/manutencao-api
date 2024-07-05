using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System.Linq;

namespace SistemaManutencao.Application.UseCases.Manutencoes
{
    public class GetAllManutencoes
    {
        private readonly IManutencaoRepository _manutencaoRepository;
        private readonly IAuthService _authService;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IMapper _mapper;

        public GetAllManutencoes(
            IManutencaoRepository manutencaoRepository,
            IAuthService authService,
            IQueryFilterService queryFilterService,
            IMapper mapper)
        {
            _manutencaoRepository = manutencaoRepository;
            _authService = authService;
            _queryFilterService = queryFilterService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetManutencaoDTO>> ExecuteAsync(Filtro filtros, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var manutencoes = await _manutencaoRepository.GetAllByEmpresaIdAsync(empresaId);

            var manutencoesFiltradas = _queryFilterService.AplicarTodosOsFiltros(manutencoes.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetManutencaoDTO>>(manutencoesFiltradas.ToList());
        }
    }
}
