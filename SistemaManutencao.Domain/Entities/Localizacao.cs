namespace SistemaManutencao.Domain.Entities
{
    public sealed class Localizacao : EntidadeCommon
    {
        public IEnumerable<CadastroGeralItem> CadastroGeralItems { get; set; }
    }
}
