using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class GetAllModelos
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllModelos(IQueryFilterService queryFilterService, IModeloRepository modeloRepository, IAuthService authService, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _queryFilterService = queryFilterService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetModeloDTO>> ExecuteAsync(Filtro filtros, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var modelos = await _modeloRepository.GetAllByEmpresaIdAsync(empresaId);

            var modelosFiltrados = _queryFilterService.AplicarTodosOsFiltros(modelos.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetModeloDTO>>(modelosFiltrados.ToList());
        }
    }
}
