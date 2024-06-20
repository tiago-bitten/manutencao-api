using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<CreateModeloDTO, Modelo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Equipamentos, opt => opt.Ignore());
            
            CreateMap<Modelo, GetModeloDTO>();

            CreateMap<UpdateModeloDTO, Modelo>()
                .ForMember(dest => dest.Equipamentos, opt => opt.Ignore());
        }
    }
}
