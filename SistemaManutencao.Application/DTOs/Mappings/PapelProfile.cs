using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Papeis;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class PapelProfile : Profile
    {
        public PapelProfile()
        {
            CreateMap<CreatePapelDTO, Papel>();

            CreateMap<Papel, GetPapelDTO>();
        }
    }
}
