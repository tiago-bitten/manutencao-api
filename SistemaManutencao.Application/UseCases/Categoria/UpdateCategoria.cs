using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Categoria;

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
            throw new Exception("Categoria não encontrada");

        categoria = _mapper.Map<Domain.Entities.Categoria>(dto);

        _categoriaRepository.Update(categoria);

        return _mapper.Map<GetCategoriaDTO>(categoria);
    }
}
