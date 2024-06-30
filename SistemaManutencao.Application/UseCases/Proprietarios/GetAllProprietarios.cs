using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;
using SistemaManutencao.Domain.Interfaces.Repositories;

namespace SistemaManutencao.Application.UseCases.Proprietarios
{
    public class GetAllProprietarios
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMapper _mapper;
        public GetAllProprietarios(IProprietarioRepository proprietarioRepository, IMapper mapper)
        {
            _proprietarioRepository = proprietarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetProprietarioDTO>> ExecuteAsync()
        {
            var proprietarios = await _proprietarioRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetProprietarioDTO>>(proprietarios);
        }
    }
}
