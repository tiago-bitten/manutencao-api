using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Domain.Entities
{
    public class Manutencao : EntidadeCommon
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public EStatusManutencao Status { get; set; }
        public ETipoManutencao TipoManutencao { get; set; }
        public Guid EquipamentoId { get; set; }

        public Equipamento Equipamento { get; set; }
    }
}
