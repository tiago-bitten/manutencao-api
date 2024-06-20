namespace SistemaManutencao.Domain.Entities
{
    public sealed class Localizacao : EntidadeCommon
    {
        public IEnumerable<Equipamento?> Equipamentos { get; set; }
    }
}
