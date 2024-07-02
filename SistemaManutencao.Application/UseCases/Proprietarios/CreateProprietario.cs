using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Proprietarios
{
    public class CreateProprietario
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IAuthService _authService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public CreateProprietario(IProprietarioRepository proprietarioRepository, IAuthService authService, IUsuarioService usuarioService, IMapper mapper)
        {
            _proprietarioRepository = proprietarioRepository;
            _authService = authService;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<GetProprietarioDTO> ExecuteAsync(CreateProprietarioDTO dto, string authHeader)
        {
            var usuarioId = _authService.GetUserId(authHeader);
            var usuario = await _usuarioService.ValidateEntityAsync(usuarioId);

            var proprietarioEmail = await _proprietarioRepository.GetByEmailAsync(dto.Email);

            if (proprietarioEmail != null)
                throw new RegraNegocioException("EX10010","Já existe um proprietário com esse e-mail");

            var proprietarioCpf = await _proprietarioRepository.GetByCpfAsync(dto.Cpf);

            if (proprietarioCpf != null)
                throw new RegraNegocioException("EX10011", "Já existe um proprietário com esse CPF");

            var proprietario = _mapper.Map<Proprietario>(dto);

            await _proprietarioRepository.AddAsync(proprietario);

            return _mapper.Map<GetProprietarioDTO>(proprietario);
        }
    }
}
