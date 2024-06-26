using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.DapperRepositories;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Tecnicos
{
    public class CreateTecnico
    {
        private readonly ITecnicoDapperRepository _tecnicoDapperRepository;
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IMapper _mapper;

        public CreateTecnico(ITecnicoDapperRepository tecnicoDapperRepository, ITecnicoRepository tecnicoRepository, IMapper mapper)
        {
            _tecnicoDapperRepository = tecnicoDapperRepository;
            _tecnicoRepository = tecnicoRepository;
            _mapper = mapper;
        }

        public async Task<GetTecnicoDTO> ExecuteAsync(CreateTecnicoDTO dto)
        {
            var tecnico = _mapper.Map<Tecnico>(dto);
            tecnico.EspecializacaoId = new Guid("77789749-76ec-4e5f-8f57-c0ad076f8a6f");
            tecnico.EmpresaId = new Guid("00000000-0000-0000-0000-000000000000");


            if (dto.PossuiAcesso.HasValue && dto.PossuiAcesso.Equals(true))
            {
                var senhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
                tecnico = await _tecnicoDapperRepository.CreateTecnicoComAcessoAsync(tecnico, dto.Email, senhaHash);
            }
            else
            {
                await _tecnicoRepository.AddAsync(tecnico);
            }

            return _mapper.Map<GetTecnicoDTO>(tecnico);
        }
    }
}
