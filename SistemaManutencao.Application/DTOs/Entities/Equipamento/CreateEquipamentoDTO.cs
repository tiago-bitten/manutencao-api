namespace SistemaManutencao.Application.DTOs.Entities.Equipamento
{
    public class CreateEquipamentoDTO
    {
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? NumeroDeSerie { get; set; }
        public DateTime? DataAquisicao { get; set; }
        public Guid? ModeloId { get; set; }
        public Guid? LocalizacaoId { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
