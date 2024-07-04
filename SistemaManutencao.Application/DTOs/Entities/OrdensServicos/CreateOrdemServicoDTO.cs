namespace SistemaManutencao.Application.DTOs.Entities.OrdensServicos
{
    public class CreateOrdemServicoDTO
    {
        public Guid ManutencaoId { get; set; }
        public Guid TecnicoId { get; set; }
        public Guid PapelId { get; set; }
    }
}
