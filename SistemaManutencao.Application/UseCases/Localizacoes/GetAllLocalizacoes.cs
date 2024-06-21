using AutoMapper;
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

        public async Task<IEnumerable<GetLocalizacaoById>> ExecuteAsync()
        {
            var localizacoes = await _localizacaoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetLocalizacaoById>>(localizacoes);
        }
    }
}
