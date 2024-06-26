namespace SistemaManutencao.Domain.Entities
{
    public sealed class PecaUsada
    {
        public Guid PecaId { get; set; }
        public Peca Peca { get; set; }

        public Guid ManutencaoId { get; set; }
        public Manutencao Manutencao { get; set; }

        public int Quantidade { get; set; }

        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
