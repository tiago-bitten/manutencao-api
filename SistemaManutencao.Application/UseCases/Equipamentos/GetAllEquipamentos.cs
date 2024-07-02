using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class GetAllEquipamentos
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllEquipamentos(IEquipamentoRepository equipamentoRepository, IAuthService authService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEquipamentoDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var equipamentos = await _equipamentoRepository.GetAllByEmpresaIdAsync(empresaId);

            if (!string.IsNullOrEmpty(nome))
                equipamentos = equipamentos.Where(e => e.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetEquipamentoDTO>>(equipamentos);
        }
    }
}
