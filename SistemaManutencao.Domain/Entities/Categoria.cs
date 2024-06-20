namespace SistemaManutencao.Domain.Entities
{
    public class Categoria : EntidadeCommon
    {
        public IEnumerable<Equipamento?> Equipamentos { get; set; }
    }
}
