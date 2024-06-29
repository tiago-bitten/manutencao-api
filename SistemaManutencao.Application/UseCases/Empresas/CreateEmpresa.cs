using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Empresas;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Empresas
{
    public class CreateEmpresa
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateEmpresa(IEmpresaRepository empresaRepository, IUsuarioService usuarioService, IAuthService authService, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _usuarioService = usuarioService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<GetEmpresaDTO> ExecuteAsync(CreateEmpresaDTO dto, string authHeader)
        {
            var usuarioId = _authService.GetUserId(authHeader);
            var usuario = await _usuarioService.ValidarExistenciaAsync(usuarioId);
            
            if (!usuario.TipoUsuario.Equals(ETipoUsuario.Funcionario))
                throw new Exception("Usuário não tem permissão para criar empresa");

            var empresa = _mapper.Map<Empresa>(dto);

            await _empresaRepository.AddAsync(empresa);

            return _mapper.Map<GetEmpresaDTO>(empresa);
        }
    }
}
