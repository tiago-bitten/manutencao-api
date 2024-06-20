using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Modelo
{
    public class CreateModelo
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IMapper _mapper;

        public CreateModelo(IModeloRepository modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        public async Task<GetModeloDTO> ExecuteAsync(CreateModeloDTO dto)
        {
            var modelo = _mapper.Map<Domain.Entities.Modelo>(dto);

            await _modeloRepository.AddAsync(modelo);

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
