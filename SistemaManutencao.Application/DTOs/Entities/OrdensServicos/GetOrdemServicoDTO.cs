using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Application.DTOs.Entities.Papeis;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;

namespace SistemaManutencao.Application.DTOs.Entities.OrdensServicos
{
    public class GetOrdemServicoDTO
    {
        public GetSimpManutencaoDTO Manutencao { get; set; }
        public GetTecnicoDTO Tecnico { get; set; }
        public GetPapelDTO Papel { get; set; }
    }
}
