namespace SistemaManutencao.Domain.Entities
{
    public sealed class Tecnico : EntidadeBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        public ICollection<OrdemServico?> OrdemServicos { get; set; }
    }
}
