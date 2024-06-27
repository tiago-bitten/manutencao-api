using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Usuarios;
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

        public Login(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<string> ExecuteAsync(LoginDTO dto)
        {
            var usuario = await _usuarioRepository.GetByEmailAsync(dto.Email);

            if (usuario is null)
                throw new EntidadeNaoEncontradaException("EX10009", "Usuario");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

            if (!senhaValida)
                throw new Exception("Senha inválida");

            return _authService.GenerateTokenAsync(usuario);
        }
    }
}
