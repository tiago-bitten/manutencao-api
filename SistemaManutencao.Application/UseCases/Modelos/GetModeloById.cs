using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class GetModeloById
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public GetModeloById(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<GetModeloDTO> ExecuteAsync(Guid id)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);

            if (modelo == null)
                throw new ArgumentException("Modelo não encontrado");

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
