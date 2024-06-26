namespace SistemaManutencao.Application.DTOs.Entities.Tecnicos
{
    public class GetTecnicoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool? PossuiAcesso { get; set; }
        public Guid EspecializacaoId { get; set; }
    }
}
