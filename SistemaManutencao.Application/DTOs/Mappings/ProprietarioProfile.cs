using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class ProprietarioProfile : Profile
    {
        public ProprietarioProfile()
        {
            CreateMap<CreateProprietarioDTO, Proprietario>();

            CreateMap<Proprietario, GetProprietarioDTO>();

            CreateMap<Proprietario, GetSimpProprietarioDTO>();
        }
    }
}
