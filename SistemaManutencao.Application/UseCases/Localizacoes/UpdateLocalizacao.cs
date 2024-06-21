using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Localizacoes
{
    public class UpdateLocalizacao
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly IMapper _mapper;

        public UpdateLocalizacao(ILocalizacaoRepository localizacaoRepository, IMapper mapper)
        {
            _localizacaoRepository = localizacaoRepository;
            _mapper = mapper;
        }

        public async Task<GetLocalizacaoById> ExecuteAsync(Guid id, UpdateLocalizacaoDTO dto)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);

            if (localizacao == null)
                throw new EntidadeNaoEncontradaException("EX10005", "Localizacao");

            localizacao = _mapper.Map<Localizacao>(dto);

            _localizacaoRepository.Update(localizacao);

            return _mapper.Map<GetLocalizacaoById>(localizacao);
        }
    }
}
