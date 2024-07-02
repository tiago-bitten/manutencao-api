using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class GetCategoriaById
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAuthService _authService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public GetCategoriaById(ICategoriaRepository categoriaRepository, IAuthService authService, ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _authService = authService;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public async Task<GetCategoriaDTO> ExecuteAsync(Guid id, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var categoria = await _categoriaService.ValidateEntityByEmpresaIdAsync(id, empresaId);

            return _mapper.Map<GetCategoriaDTO>(categoria);
        }
    }
}
