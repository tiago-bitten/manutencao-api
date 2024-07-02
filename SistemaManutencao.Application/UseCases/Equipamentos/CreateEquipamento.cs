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
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public CreateEquipamento(IEquipamentoRepository equipamentoRepository, IModeloService modeloService, ILocalizacaoService localizacaoService, ICategoriaService categoriaService, IAuthService authService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _modeloService = modeloService;
            _localizacaoService = localizacaoService;
            _categoriaService = categoriaService;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<GetEquipamentoDTO> ExecuteAsync(CreateEquipamentoDTO dto, string authHeader)
        {
            var empresaId = _authService.GetEmpresaId(authHeader);

            var equipamento = _mapper.Map<Equipamento>(dto);

            if (dto.ModeloId.HasValue)
                equipamento.Modelo = await _modeloService.ValidateEntityByEmpresaIdAsync(dto.ModeloId.Value, empresaId);

            if (dto.CategoriaId.HasValue)
                equipamento.Categoria = await _categoriaService.ValidateEntityByEmpresaIdAsync(dto.CategoriaId.Value, empresaId);

            if (dto.LocalizacaoId.HasValue)
                equipamento.Localizacao = await _localizacaoService.ValidateEntityByEmpresaIdAsync(dto.LocalizacaoId.Value, empresaId);

            equipamento.EmpresaId = empresaId;

            await _equipamentoRepository.AddAsync(equipamento);

            return _mapper.Map<GetEquipamentoDTO>(equipamento);
        }
    }
}
