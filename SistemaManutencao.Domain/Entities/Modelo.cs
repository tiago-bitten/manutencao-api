namespace SistemaManutencao.Domain.Entities
{
    public sealed class Modelo : EntidadeCommon
    {
        public IEnumerable<CadastroGeralItem?> CadastroGeralItems { get; set; }
    }
}
