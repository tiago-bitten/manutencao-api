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
        private readonly IEspecializacaoService _especializacaoService;
        private readonly IMapper _mapper;

        public CreateTecnico(ITecnicoDapperRepository tecnicoDapperRepository, ITecnicoRepository tecnicoRepository, IEspecializacaoService especializacaoService, IMapper mapper)
        {
            _tecnicoDapperRepository = tecnicoDapperRepository;
            _tecnicoRepository = tecnicoRepository;
            _especializacaoService = especializacaoService;
            _mapper = mapper;
        }

        public async Task<GetTecnicoDTO> ExecuteAsync(CreateTecnicoDTO dto)
        {
            var tecnico = _mapper.Map<Tecnico>(dto);

            if (dto.EspecializacaoId.HasValue)
            {
                tecnico.Especializacao = await _especializacaoService.ValidarExistenciaAsync(dto.EspecializacaoId.Value);
            }


            if (dto.PossuiAcesso.HasValue && dto.PossuiAcesso.Equals(true))
            {
                var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
                tecnico.EmpresaId = Guid.Parse("3a9485f7-33cf-4558-a511-b457b07e8aac");
                tecnico = await _tecnicoDapperRepository.CreateTecnicoComAcessoAsync(tecnico, dto.Email, senhaHash);
                //tecnico = await _tecnicoRepository.CreateTecnicoComAcessoAsync(tecnico, dto.Email, senhaHash);
            }
            else
            {
                await _tecnicoRepository.AddAsync(tecnico);
            }
            return _mapper.Map<GetTecnicoDTO>(tecnico);
        }
    }
}
