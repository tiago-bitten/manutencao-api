using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Empresas;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaDTO, Empresa>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Proprietario, opts => opts.Ignore());

            CreateMap<Empresa, GetEmpresaDTO>();
        }
    }
}
