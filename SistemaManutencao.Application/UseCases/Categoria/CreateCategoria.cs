using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Entities;

namespace UseCases
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
            var categoria = _mapper.Map<Categoria>(dto);

            await _categoriaRepository.AddAsync(categoria);

            return _mapper.Map<GetCategoriaDTO>(categoria);
        }
    }
}
