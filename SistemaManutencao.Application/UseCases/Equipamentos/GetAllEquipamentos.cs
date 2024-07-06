using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class GetAllEquipamentos
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IQueryFilterService _queryFilterService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllEquipamentos(IQueryFilterService queryFilterService, IEquipamentoRepository equipamentoRepository, IAuthService authService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _queryFilterService = queryFilterService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEquipamentoDTO>> ExecuteAsync(Filtro filtros, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var equipamentos = await _equipamentoRepository.GetAllByEmpresaIdAsync(empresaId);

            var equipamentosFiltrados = _queryFilterService.AplicarTodosOsFiltros(equipamentos.AsQueryable(), filtros);

            return _mapper.Map<IEnumerable<GetEquipamentoDTO>>(equipamentosFiltrados.ToList());
        }
    }
}
