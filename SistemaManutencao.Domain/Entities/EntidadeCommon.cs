namespace SistemaManutencao.Domain.Entities
{
    public abstract class EntidadeCommon : EntidadeBase
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
