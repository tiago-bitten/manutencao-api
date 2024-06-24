using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class GetAllModelos
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public GetAllModelos(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetModeloDTO>> ExecuteAsync(string? nome)
        {
            var modelos = await _modeloRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(nome))
                modelos = modelos.Where(m => m.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetModeloDTO>>(modelos);
        }
    }
}
