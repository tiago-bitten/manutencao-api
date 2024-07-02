using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Modelos
{
    public class CreateModelo
    {
        private readonly IModeloRepository _modeloRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateModelo(IModeloRepository modeloRepository, IMapper mapper, IAuthService authService)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<GetModeloDTO> ExecuteAsync(CreateModeloDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var modelo = _mapper.Map<Modelo>(dto);

            modelo.EmpresaId = empresaId;

            await _modeloRepository.AddAsync(modelo);

            return _mapper.Map<GetModeloDTO>(modelo);
        }
    }
}
