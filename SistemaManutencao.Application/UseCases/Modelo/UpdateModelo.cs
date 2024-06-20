using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelo
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

        public async Task<GetModeloDTO> ExecuteAsync(Guid id, UpdateModelo dto)
        {
            var modelo = await _modeloRepository.GetByIdAsync(id);

            if (modelo == null)
                throw new ArgumentException("Modelo não encontrado");

            modelo = _mapper.Map<Domain.Entities.Modelo>(modelo);

            _modeloRepository.Update(modelo);

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
