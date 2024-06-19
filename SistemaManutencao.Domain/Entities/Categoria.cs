namespace SistemaManutencao.Domain.Entities
{
    public class Categoria : EntidadeCommon
    {
        public IEnumerable<CadastroGeralItem> CadastroGeralItems { get; set; }
    }
}
