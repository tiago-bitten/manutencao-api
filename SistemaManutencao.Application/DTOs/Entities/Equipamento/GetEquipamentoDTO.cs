using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Application.DTOs.Entities.Modelo;

namespace SistemaManutencao.Application.DTOs.Entities.Equipamento
{
    public class GetEquipamentoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? NumeroDeSerie { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public GetCategoriaDTO? Categoria { get; set; }
        public GetModeloDTO? Modelo { get; set; }
        public GetLocalizacaoDTO? Localizacao { get; set; }
    }
}
