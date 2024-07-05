using SistemaManutencao.Application.DTOs.Entities.Papeis;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;

namespace SistemaManutencao.Application.DTOs.Entities.OrdensServicos
{
    public class GetSimpOrdemServicoDTO
    {
        public GetTecnicoDTO Tecnico { get; set; }
        public GetPapelDTO Papel { get; set; }
    }
}
