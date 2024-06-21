using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Categorias
{
    public class CreateCategoria
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CreateCategoria(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<GetCategoriaDTO> ExecuteAsync(CreateCategoriaDTO dto)
        {
            var categoria = _mapper.Map<Domain.Entities.Categoria>(dto);

            await _categoriaRepository.AddAsync(categoria);

            return _mapper.Map<GetCategoriaDTO>(categoria);
        }
    }
}
