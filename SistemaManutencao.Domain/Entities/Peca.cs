namespace SistemaManutencao.Domain.Entities
{
    public class Peca : EntidadeCommon
    {
        public ICollection<EquipamentoPeca?> EquipamentoPecas { get; set; }
        public ICollection<PecaUsada?> PecasUsadas { get; set; }
    }
}
