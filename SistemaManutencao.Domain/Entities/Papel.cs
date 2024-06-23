namespace SistemaManutencao.Domain.Entities
{
    public sealed class Papel : EntidadeCommon
    {
        public ICollection<OrdemServico?> OrdensServicos { get; set; }
    }
}
