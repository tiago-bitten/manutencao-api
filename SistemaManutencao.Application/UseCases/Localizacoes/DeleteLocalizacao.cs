using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class DeleteLocalizacao
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly ILocalizacaoService _localizacaoService;

        public DeleteLocalizacao(ILocalizacaoRepository localizacaoRepository, ILocalizacaoService localizacaoService)
        {
            _localizacaoRepository = localizacaoRepository;
            _localizacaoService = localizacaoService;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var localizacao = await _localizacaoService.ValidarExistenciaAsync(id);

            _localizacaoRepository.Remove(localizacao);
        }
    }
}
