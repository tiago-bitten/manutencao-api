using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class CreateLocalizacao
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IMapper _mapper;

        public CreateLocalizacao(ILocalizacaoRepository localizacaoRepository, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
        }

        public async Task<GetLocalizacaoDTO> ExecuteAsync(CreateLocalizacaoDTO dto)
        {
            var localizacao = _mapper.Map<Localizacao>(dto);

            await _localizacaoRepository.AddAsync(localizacao);

            return _mapper.Map<GetLocalizacaoDTO>(localizacao);
        }
    }
}
