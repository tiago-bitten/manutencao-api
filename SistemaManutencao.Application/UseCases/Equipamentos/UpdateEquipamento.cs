using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Exceptions;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace SistemaManutencao.Application.UseCases.Equipamentos
{
    public class UpdateEquipamento
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IModeloService _modeloService;
        private readonly ILocalizacaoService _localizacaoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public UpdateEquipamento(IEquipamentoRepository equipamentoRepository, IModeloService modeloService, ILocalizacaoService localizacaoService, ICategoriaService categoriaService, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _modeloService = modeloService;
            _localizacaoService = localizacaoService;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public async Task<GetEquipamentoDTO> ExecuteAsync(Guid id, UpdateEquipamentoDTO dto)
        {
            var equipamento = await _equipamentoRepository.GetByIdAsync(id);

            if (equipamento == null)
                throw new EntidadeNaoEncontradaException("EX10002", "Equipamento");

            if (!string.IsNullOrEmpty(dto.Nome))
                equipamento.Nome = dto.Nome;

            if (!string.IsNullOrEmpty(dto.Descricao))
                equipamento.Descricao = dto.Descricao;

            if (dto.ModeloId.HasValue)
                equipamento.Modelo = await _modeloService.ValidarExistenciaAsync(dto.ModeloId.Value);

            if (dto.LocalizacaoId.HasValue)
                equipamento.Localizacao = await _localizacaoService.ValidarExistenciaAsync(dto.LocalizacaoId.Value);

            if (dto.CategoriaId.HasValue)
                equipamento.Categoria = await _categoriaService.ValidarExistenciaAsync(dto.CategoriaId.Value);

            _equipamentoRepository.Update(equipamento);

            return _mapper.Map<GetEquipamentoDTO>(equipamento);
        }
    }
}
