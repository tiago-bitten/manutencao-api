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
        private readonly IEmpresaService _empresaService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateCategoria(ICategoriaRepository categoriaRepository, IEmpresaService empresaService, IAuthService authService, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _empresaService = empresaService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<GetCategoriaDTO> ExecuteAsync(CreateCategoriaDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var empresa = await _empresaService.ValidateEntityAsync(empresaId);

            var categoria = _mapper.Map<Categoria>(dto);

            categoria.Empresa = empresa;

            await _categoriaRepository.AddAsync(categoria);

            return _mapper.Map<GetCategoriaDTO>(categoria);
        }
    }
}
