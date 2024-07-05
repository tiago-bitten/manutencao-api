using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.OrdensServicos;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class OrdemServicoProfile : Profile
    {
        public OrdemServicoProfile()
        {
            CreateMap<CreateOrdemServicoDTO, OrdemServico>();

            CreateMap<OrdemServico, GetSimpOrdemServicoDTO>()
                .ForMember(dest => dest.Tecnico, opt => opt.MapFrom(x => x.Tecnico))
                .ForMember(dest => dest.Papel, opt => opt.MapFrom(x => x.Papel));

            CreateMap<OrdemServico, GetOrdemServicoDTO>()
                .ForMember(dest => dest.Manutencao, opt => opt.MapFrom(x => x.Manutencao))
                .ForMember(dest => dest.Tecnico, opt => opt.MapFrom(x => x.Tecnico))
                .ForMember(dest => dest.Papel, opt => opt.MapFrom(x => x.Papel));
        }
    }
}
