using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Empresas;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Empresas
{
    public class GetAllEmpresas
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public GetAllEmpresas(IEmpresaRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetEmpresaDTO>> ExecuteAsync()
        {
            var empresas = await _empresaRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetEmpresaDTO>>(empresas);
        }
    }
}
