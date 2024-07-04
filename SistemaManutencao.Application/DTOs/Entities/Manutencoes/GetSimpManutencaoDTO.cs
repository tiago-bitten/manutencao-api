using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Application.DTOs.Entities.Manutencoes
{
    public class GetSimpManutencaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public EStatusManutencao Status { get; set; }
        public ETipoManutencao TipoManutencao { get; set; }
        public GetEquipamentoDTO Equipamento { get; set; }
    }
}
