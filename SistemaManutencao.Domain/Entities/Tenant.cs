namespace SistemaManutencao.Domain.Entities
{
    public abstract class Tenant
    {
        public Guid EmpresaId { get; private set; }
        public Empresa Empresa { get; private set; }
    }
}
