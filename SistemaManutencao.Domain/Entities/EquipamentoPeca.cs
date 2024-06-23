namespace SistemaManutencao.Domain.Entities
{
    public sealed class EquipamentoPeca
    {
        public Guid EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }

        public Guid PecaId { get; set; }
        public Peca Peca { get; set; }
    }
}
