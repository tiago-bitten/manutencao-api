using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Domain.Entities
{
    public sealed class Usuario : EntidadeBase
    {
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public bool? Ativo { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public Guid? TecnicoId { get; set; }
        public Tecnico? Tecnico { get; set; }
    }
}
