using SistemaManutencao.Domain.Enums;

namespace SistemaManutencao.Domain.Entities
{
    public sealed class Empresa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public ETipoEmpresa TipoEmpresa { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Cep { get; set; }
        public bool? Ativo { get; set; }
        public Guid ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }

        public IEnumerable<Categoria?> Categorias { get; set; }
        public IEnumerable<Equipamento?> Equipamentos { get; set; }
        public IEnumerable<EquipamentoPeca?> EquipamentoPecas { get; set; }
        public IEnumerable<Especializacao?> Especializacoes { get; set; }
        public IEnumerable<Ferramenta?> Ferramentas { get; set; }
        public IEnumerable<Localizacao?> Localizacoes { get; set; }
        public IEnumerable<Manutencao?> Manutencoes { get; set; }
        public IEnumerable<Modelo?> Modelos { get; set; }
        public IEnumerable<OrdemServico?> OrdensServicos { get; set; }
        public IEnumerable<Peca?> Pecas { get; set; }
        public IEnumerable<Papel?> Papeis { get; set; }
        public IEnumerable<PecaUsada> PecasUsadas { get; set; }
        public IEnumerable<Tecnico?> Tecnicos { get; set; }
        public IEnumerable<Usuario?> Usuarios { get; set; } 
    }
}
