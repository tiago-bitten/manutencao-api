using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Tecnicos
{
    public class GetAllTecnicos
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllTecnicos(ITecnicoRepository tecnicoRepository, IAuthService authService, IMapper mapper)
        {
            _tecnicoRepository = tecnicoRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTecnicoDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var tecnicos = await _tecnicoRepository.GetAllByEmpresaIdAsync(empresaId);

            if (!string.IsNullOrEmpty(nome))
                tecnicos = tecnicos.Where(t => t.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetTecnicoDTO>>(tecnicos);
        }
    }
}
