using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class EquipamentoProfile : Profile
    {
        public EquipamentoProfile()
        {
            CreateMap<CreateEquipamentoDTO, Equipamento>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Localizacao, opt => opt.Ignore())
                .ForMember(dest => dest.TotalManutencoesConcluidas, opt => opt.Ignore());

            CreateMap<Equipamento, GetEquipamentoDTO>();
            
            CreateMap<UpdateEquipamentoDTO, Equipamento>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Modelo, opt => opt.Ignore())
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Localizacao, opt => opt.Ignore())
                .ForMember(dest => dest.TotalManutencoesConcluidas, opt => opt.Ignore());
        }
    }
}
