namespace SistemaManutencao.Application.DTOs.Entities.Proprietarios
{
    public class CreateProprietarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
