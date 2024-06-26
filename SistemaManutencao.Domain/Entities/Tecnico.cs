namespace SistemaManutencao.Domain.Entities
{
    public sealed class Tecnico : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public bool? PossuiAcesso { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid? EspecializacaoId { get; set; }

        public Especializacao? Especializacao { get; set; }
        public ICollection<OrdemServico?> OrdensServicos { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
