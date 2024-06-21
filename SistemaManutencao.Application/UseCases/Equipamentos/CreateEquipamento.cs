using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class CreateEquipamento
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IModeloService _modeloService;
        private readonly ILocalizacaoService _localizacaoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CreateEquipamento(IEquipamentoRepository equipamentoRepository, IModeloService modeloService, ILocalizacaoService localizacaoService, ICategoriaService categoriaService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _modeloService = modeloService;
            _localizacaoService = localizacaoService;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public async Task<GetEquipamentoDTO> ExecuteAsync(CreateEquipamentoDTO dto)
        {
            var equipamento = _mapper.Map<Equipamento>(dto);

            if (dto.ModeloId.HasValue)
                equipamento.Modelo = await _modeloService.ValidarExistenciaAsync(dto.ModeloId.Value);

            if (dto.CategoriaId.HasValue)
                equipamento.Categoria = await _categoriaService.ValidarExistenciaAsync(dto.CategoriaId.Value);

            if (dto.LocalizacaoId.HasValue)
                equipamento.Localizacao = await _localizacaoService.ValidarExistenciaAsync(dto.LocalizacaoId.Value);

            await _equipamentoRepository.AddAsync(equipamento);

            return _mapper.Map<GetEquipamentoDTO>(equipamento);
        }
    }
}
