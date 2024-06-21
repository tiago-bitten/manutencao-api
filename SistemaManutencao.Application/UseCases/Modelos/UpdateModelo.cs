using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class UpdateModelo
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public UpdateModelo(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<GetModeloDTO> ExecuteAsync(Guid id, UpdateModeloDTO dto)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);

            if (modelo == null)
                throw new ArgumentException("Modelo não encontrado");

            modelo = _mapper.Map<Domain.Entities.Modelo>(dto);

            _modeloRepository.Update(modelo);

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
