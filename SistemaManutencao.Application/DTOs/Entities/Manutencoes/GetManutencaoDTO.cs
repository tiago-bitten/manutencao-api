using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Application.DTOs.Entities.OrdensServicos;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaManutencao.Application.DTOs.Entities.Manutencoes
{
    public class GetManutencaoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataConclusao { get; set; }
        public EStatusManutencao Status { get; set; }
        public ETipoManutencao TipoManutencao { get; set; }
        public GetEquipamentoDTO Equipamento { get; set; }
        public IEnumerable<GetSimpOrdemServicoDTO?> Tecnicos { get; set; }
    }
}
