using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class LocalizacaoProfile : Profile
    {
        public LocalizacaoProfile()
        {
            CreateMap<Localizacao, GetLocalizacaoDTO>()
                .ReverseMap();

            CreateMap<CreateLocalizacaoDTO, Localizacao>()
                .ForMember(dest => dest.Equipamentos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            
            CreateMap<UpdateLocalizacaoDTO, Localizacao>()
                .ForMember(dest => dest.Equipamentos, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
