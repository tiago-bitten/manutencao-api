using AutoMapper;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Application.DTOs.Mappings
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<CreateCategoriaDTO, Categoria>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CadastroGeralItems, opt => opt.Ignore());

            CreateMap<Categoria, GetCategoriaDTO>();
        }
    }
}
