using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Categorias
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

        public async Task<IEnumerable<GetCategoriaDTO>> ExecuteAsync(string? nome)
        {
            var categorias = await _categoriaRepository.GetAllAsync();

            if  (!string.IsNullOrEmpty(nome))
                categorias = categorias.Where(c => c.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetCategoriaDTO>>(categorias);
        }
    }
}
