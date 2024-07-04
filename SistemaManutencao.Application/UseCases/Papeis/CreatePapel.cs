using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Papeis;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System.Runtime.CompilerServices;

namespace SistemaManutencao.Application.UseCases.Papeis
{
    public class CreatePapel
    {
        private readonly IPapelRepository _papelRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreatePapel(IPapelRepository papelRepository, IAuthService authService, IMapper mapper)
        {
            _papelRepository = papelRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<GetPapelDTO> ExecuteAsync(CreatePapelDTO createPapelDTO, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var papel = _mapper.Map<Papel>(createPapelDTO);

            papel.EmpresaId = empresaId;

            await _papelRepository.AddAsync(papel);

            return _mapper.Map<GetPapelDTO>(papel);
        }
    }
}
