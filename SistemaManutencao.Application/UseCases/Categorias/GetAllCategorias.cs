using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class GetAllCategorias
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllCategorias(ICategoriaRepository categoriaRepository, IAuthService authService, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoriaDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var categorias = await _categoriaRepository.GetAllByEmpresaIdAsync(empresaId);

            if  (!string.IsNullOrEmpty(nome))
                categorias = categorias.Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetCategoriaDTO>>(categorias);
        }
    }
}
