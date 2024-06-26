namespace SistemaManutencao.Domain.Entities
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }

        public Empresa Empresa { get; set; }
    }
}
