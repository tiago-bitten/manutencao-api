using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class GetAllModelos
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllModelos(IModeloRepository modeloRepository, IAuthService authService, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetModeloDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var modelos = await _modeloRepository.GetAllByEmpresaIdAsync(empresaId);

            if (!string.IsNullOrEmpty(nome))
                modelos = modelos.Where(m => m.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetModeloDTO>>(modelos);
        }
    }
}
