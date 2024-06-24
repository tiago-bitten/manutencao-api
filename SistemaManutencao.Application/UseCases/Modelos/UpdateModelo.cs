using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class UpdateModelo
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;

        public UpdateModelo(IModeloRepository modeloRepository, IModeloService modeloService, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _modeloService = modeloService;
            _mapper = mapper;
        }

        public async Task<GetModeloDTO> ExecuteAsync(Guid id, UpdateModeloDTO dto)
        {
            var modelo = await _modeloService.ValidarExistenciaAsync(id);

            modelo = _mapper.Map<Modelo>(dto);

            _modeloRepository.Update(modelo);

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
