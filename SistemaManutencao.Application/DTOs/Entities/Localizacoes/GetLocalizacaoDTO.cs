namespace SistemaManutencao.Application.DTOs.Entities.Localizacoes
{
    public class GetLocalizacaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
