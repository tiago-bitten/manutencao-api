using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Proprietarios
{
    public class GetAllProprietarios
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IMapper _mapper;
        public GetAllProprietarios(IQueryFilterService queryFilterService, IProprietarioRepository proprietarioRepository, IMapper mapper)
        {
            _proprietarioRepository = proprietarioRepository;
            _queryFilterService = queryFilterService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProprietarioDTO>> ExecuteAsync(Filtro filtros)
        {
            var proprietarios = await _proprietarioRepository.GetAllAsync();

            var proprietariosFiltrados = _queryFilterService.AplicarTodosOsFiltros(proprietarios.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetProprietarioDTO>>(proprietariosFiltrados.ToList());
        }
    }
}
