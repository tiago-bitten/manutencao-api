using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Auth;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Auth
{
    public class Login
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public Login(IUsuarioRepository usuarioRepository, IAuthService autheService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _authService = autheService;
            _mapper = mapper;
        }

        public async Task<TokenDTO> ExecuteAsync(LoginDTO dto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(dto.Email);

            if (usuario == null)
                throw new EntidadeNaoEncontradaException("EX10009", "Usuario");

            if  (!usuario.Ativo.HasValue || !usuario.Ativo.Value)
                throw new RegraNegocioException("EX10013", "Usuario está inativo, contate um administrador");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new RegraNegocioException("EX10014", "Senha inválida");

            return new TokenDTO()
            {
                Token = _authService.GenerateTokenAsync(usuario)
            };
        }
    }
}
