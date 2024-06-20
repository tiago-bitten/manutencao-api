using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelo
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

        public async Task<IEnumerable<GetModeloDTO>> ExecuteAsync()
        {
            var modelos = await _modeloRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetModeloDTO>>(modelos);
        }
    }
}
