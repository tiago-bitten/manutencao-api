namespace SistemaManutencao.Domain.Entities
{
    public sealed class OrdemServico
    {
        public Guid ManutencaoId { get; set; }
        public Manutencao Manutencao { get; set; }

        public Guid TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }

        public Guid PapelId { get; set; }
        public Papel Papel { get; set; }
    }
}
