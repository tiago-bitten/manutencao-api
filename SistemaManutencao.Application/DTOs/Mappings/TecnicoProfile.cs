using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class TecnicoProfile : Profile
    {
        public TecnicoProfile()
        {
            CreateMap<CreateTecnicoDTO, Tecnico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Especializacao, opt => opt.Ignore());

            CreateMap<Tecnico, GetTecnicoDTO>()
                .ForMember(dest => dest.PossuiAcesso, opt => opt.MapFrom(src => src.PossuiAcesso));
        }
    }
}
