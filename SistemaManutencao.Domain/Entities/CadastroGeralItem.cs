using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Domain.Entities
{
    public sealed class CadastroGeralItem : EntidadeCommon
    {
        public long NumeroDeSerie { get; set; }
        public DateTime DataAquisicao { get; set; }
        public Guid ModeloId { get; set; }
        public Guid LocalizacaoId { get; set; }
        public Guid CategoriaId { get; set; }
        public int Quantidade { get; set; }
        public ETipoItem TipoItem { get; set; }

        public Modelo Modelo { get; set; }
        public Localizacao Localizacao { get; set; }
        public Categoria Categoria { get; set; }
    }
}
