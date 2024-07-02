using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class CreateCategoria
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateCategoria(ICategoriaRepository categoriaRepository, IAuthService authService, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<GetCategoriaDTO> ExecuteAsync(CreateCategoriaDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var categoria = _mapper.Map<Categoria>(dto);

            categoria.EmpresaId = empresaId;

            await _categoriaRepository.AddAsync(categoria);

            return _mapper.Map<GetCategoriaDTO>(categoria);
        }
    }
}
