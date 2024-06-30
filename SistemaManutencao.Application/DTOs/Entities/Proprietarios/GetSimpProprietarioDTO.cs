namespace SistemaManutencao.Application.DTOs.Entities.Proprietarios
{
    public class GetSimpProprietarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool? Ativo { get; set; }
    }
}
