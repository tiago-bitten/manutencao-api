using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class GetLocalizacaoById
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private IMapper _mapper;

        public GetLocalizacaoById(ILocalizacaoRepository localizacaoRepository, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
        }

        public async Task<GetLocalizacaoDTO> ExecuteAsync(Guid id)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);

            if (localizacao == null)
                throw new EntidadeNaoEncontradaException("EX10004", "Localizacao");

            return _mapper.Map<GetLocalizacaoDTO>(localizacao);
        }
    }
}
