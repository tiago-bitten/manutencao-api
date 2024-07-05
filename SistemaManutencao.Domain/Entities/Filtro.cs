namespace SistemaManutencao.Domain.Entities
{
    public sealed class Filtro
    {
        public Dictionary<string, string?> Filtrar { get; set; } = new Dictionary<string, string?>();
        public string OrdenarPor { get; set; }
        public bool OrdemAsc { get; set; } = true;
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
    }
}
