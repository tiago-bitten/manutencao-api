namespace SistemaManutencao.Domain.Entities
{
    public sealed class Modelo : EntidadeCommon
    {
        public IEnumerable<Equipamento?> Equipamentos { get; set; }
    }
}
