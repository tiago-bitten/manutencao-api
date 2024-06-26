namespace SistemaManutencao.Application.DTOs.Entities.Tecnicos
{
    public class CreateTecnicoDTO
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? PossuiAcesso { get; set; }
        public Guid? EspecializacaoId { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}
