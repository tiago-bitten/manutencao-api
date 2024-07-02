using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Categorias;

public class UpdateCategoria
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly ICategoriaService _categoriaService;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UpdateCategoria(ICategoriaRepository categoriaRepository, IMapper mapper, IAuthService authService, ICategoriaService categoriaService)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
        _authService = authService;
        _categoriaService = categoriaService;
    }

    public async Task<GetCategoriaDTO> ExecuteAsync(Guid id, UpdateCategoriaDTO dto, string authHeader)
    {
        var empresaId = _authService.GetEmpresaId(authHeader);
        
        var categoria = await _categoriaService.ValidateEntityByEmpresaIdAsync(id, empresaId);

        if (!string.IsNullOrEmpty(dto.Nome))
            categoria.Nome = dto.Nome;

        if (!string.IsNullOrEmpty(dto.Descricao))
            categoria.Descricao = dto.Descricao;

        _categoriaRepository.Update(categoria);

        return _mapper.Map<GetCategoriaDTO>(categoria);
    }
}
