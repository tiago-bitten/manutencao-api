using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.DapperRepositories;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Tecnicos
{
    public class CreateTecnico
    {
        private readonly ITecnicoDapperRepository _tecnicoDapperRepository;
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        private readonly IEspecializacaoService _especializacaoService;
        private readonly IMapper _mapper;

        public CreateTecnico(ITecnicoDapperRepository tecnicoDapperRepository, ITecnicoRepository tecnicoRepository, IUsuarioRepository usuarioRepository, IAuthService authService, IEspecializacaoService especializacaoService, IMapper mapper)
        {
            _tecnicoDapperRepository = tecnicoDapperRepository;
            _tecnicoRepository = tecnicoRepository;
            _usuarioRepository = usuarioRepository;
            _authService = authService;
            _especializacaoService = especializacaoService;
            _mapper = mapper;
        }

        public async Task<GetTecnicoDTO> ExecuteAsync(CreateTecnicoDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var tecnico = _mapper.Map<Tecnico>(dto);

            if (dto.EspecializacaoId.HasValue)
                tecnico.Especializacao = await _especializacaoService.ValidateEntityByEmpresaIdAsync(dto.EspecializacaoId.Value, empresaId);

            tecnico.EmpresaId = empresaId;

            if (dto.PossuiAcesso.HasValue && dto.PossuiAcesso.Equals(true))
            {
                var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

                var usuario = new Usuario
                {
                    Email = dto.Email,
                    SenhaHash = senhaHash,
                    Ativo = true,
                    EmpresaId = empresaId
                };

                await _tecnicoRepository.AddAsync(tecnico);

                usuario.Tecnico = tecnico;

                await _usuarioRepository.AddAsync(usuario);
            }
            else
            {
                await _tecnicoRepository.AddAsync(tecnico);
            }
            return _mapper.Map<GetTecnicoDTO>(tecnico);
        }
    }
}
