using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class ManutencaoProfile : Profile
    {
        public ManutencaoProfile()
        {
            CreateMap<CreateManutencaoDTO, Manutencao>();

            CreateMap<Manutencao, GetManutencaoDTO>()
                .ForMember(dest => dest.Tecnicos, opt => opt.MapFrom(x => x.OrdemServicos));

            CreateMap<Manutencao, GetSimpManutencaoDTO>();
        }
    }
}
