namespace SistemaManutencao.Domain.Entities
{
    public abstract class Tenant
    {
        public Guid EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
