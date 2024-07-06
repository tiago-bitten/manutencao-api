using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class GetAllCategorias
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllCategorias(IQueryFilterService queryFilterService, ICategoriaRepository categoriaRepository, IAuthService authService, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _queryFilterService = queryFilterService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoriaDTO>> ExecuteAsync(Filtro filtros, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var categorias = await _categoriaRepository.GetAllByEmpresaIdAsync(empresaId);

            var categoriasFiltradas = _queryFilterService.AplicarTodosOsFiltros(categorias.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetCategoriaDTO>>(categoriasFiltradas.ToList());
        }
    }
}
