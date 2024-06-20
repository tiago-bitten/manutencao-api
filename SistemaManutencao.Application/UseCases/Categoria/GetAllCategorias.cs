using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Categoria
{
    public class GetAllCategorias
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public GetAllCategorias(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCategoriaDTO>> ExecuteAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();

            throw new KeyNotFoundException("Recurso não encontrado11111");

            return _mapper.Map<IEnumerable<GetCategoriaDTO>>(categorias);
        }
    }
}
