using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaManutencao.Application.UseCases.Manutencoes
{
    public class GetAllManutencoes
    {
        private readonly IManutencaoRepository _manutencaoRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public GetAllManutencoes(
            IManutencaoRepository manutencaoRepository,
            IAuthService authService,
            IMapper mapper)
        {
            _manutencaoRepository = manutencaoRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetManutencaoDTO>> ExecuteAsync(string? nome, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var manutencoes = await _manutencaoRepository.GetAllByEmpresaIdAsync(empresaId);

            var filteredManutencoes = FilterManutencoes(manutencoes, nome);

            return _mapper.Map<IEnumerable<GetManutencaoDTO>>(filteredManutencoes);
        }

        private IEnumerable<Manutencao> FilterManutencoes(IEnumerable<Manutencao> manutencoes, string? nome)
        {
            if (!string.IsNullOrEmpty(nome))
                return manutencoes.Where(m => m.Nome.Contains(nome));

            return manutencoes;
        }
    }
}
