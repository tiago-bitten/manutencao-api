using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class GetAllLocalizacoes
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IMapper _mapper;

        public GetAllLocalizacoes(ILocalizacaoRepository localizacaoRepository, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetLocalizacaoDTO>> ExecuteAsync(string? nome)
        {
            var localizacoes = await _localizacaoRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(nome))
                localizacoes = localizacoes.Where(l => l.Nome.ToUpper().Contains(nome.ToUpper()));

            return _mapper.Map<IEnumerable<GetLocalizacaoDTO>>(localizacoes);
        }
    }
}
