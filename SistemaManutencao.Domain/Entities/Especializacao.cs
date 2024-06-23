namespace SistemaManutencao.Domain.Entities
{
    public sealed class Especializacao : EntidadeCommon
    {
        public ICollection<Tecnico?> Tecnicos { get; set; }
    }
}
