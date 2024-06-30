using SistemaManutencao.Application.DTOs.Entities.Empresas;

namespace SistemaManutencao.Application.DTOs.Entities.Proprietarios
{
    public class GetProprietarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public bool? Ativo { get; set; }
        public IEnumerable<GetSimpEmpresaDTO> Empresas { get; set; }
    }
}
