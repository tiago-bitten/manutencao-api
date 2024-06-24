using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Categorias;

public class UpdateCategoria
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    public UpdateCategoria(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }

    public async Task<GetCategoriaDTO> ExecuteAsync(Guid id, UpdateCategoriaDTO dto)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);

        if (categoria == null)
            throw new EntidadeNaoEncontradaException("EX10003", "Categoria");

        if (!string.IsNullOrEmpty(dto.Nome))
            categoria.Nome = dto.Nome;

        if (!string.IsNullOrEmpty(dto.Descricao))
            categoria.Descricao = dto.Descricao;

        _categoriaRepository.Update(categoria);

        return _mapper.Map<GetCategoriaDTO>(categoria);
    }
}
