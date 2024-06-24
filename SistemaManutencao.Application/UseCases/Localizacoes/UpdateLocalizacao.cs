using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
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

        public async Task<GetLocalizacaoDTO> ExecuteAsync(Guid id, UpdateLocalizacaoDTO dto)
        {
            var localizacao = await _localizacaoRepository.GetByIdAsync(id);

            if (localizacao == null)
                throw new EntidadeNaoEncontradaException("EX10005", "Localizacao");

            if (!string.IsNullOrEmpty(dto.Nome))
                localizacao.Nome = dto.Nome;

            if (!string.IsNullOrEmpty(dto.Descricao))
                localizacao.Descricao = dto.Descricao;

            _localizacaoRepository.Update(localizacao);

            return _mapper.Map<GetLocalizacaoDTO>(localizacao);
        }
    }
}
