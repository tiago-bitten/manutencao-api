using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Application.DTOs.Entities.Manutencoes
{
    public class CreateManutencaoDTO
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public EStatusManutencao Status { get; set; }
        public ETipoManutencao TipoManutencao { get; set; }
        public Guid EquipamentoId { get; set; }
    }
}
