using AutoMapper;
using Connect.Auth.DTO;
using Connect.Auth.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AtestadoModel, AtestadoDTO>().ReverseMap();
        CreateMap<FeriasModel, FeriasDTO>().ReverseMap();
        CreateMap<FolhaPontoDTO, FolhaPontoModel>()
          .ForMember(dest => dest.NomeColaborador, opt => opt.MapFrom(src => src.Funcionario.Nome))
          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Funcionario.Email));

        CreateMap<FolhaPontoDTO, FolhaPontoModel>()
        .ForMember(dest => dest.NomeColaborador,
               opt => opt.MapFrom(src => $"{src.Funcionario.Nome} {src.Funcionario.Sobrenome}"));

        CreateMap<FolhaPontoModel, FolhaPontoDTO>();
        CreateMap<RelatoBugDTO, RelatoBugModel>().ReverseMap();
        
    }
}
