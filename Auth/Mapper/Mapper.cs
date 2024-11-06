using AutoMapper;
using Connect.Auth.DTO;
using Connect.Auth.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AtestadoModel, AtestadoDTO>().ReverseMap();
        CreateMap<FeriasModel, FeriasDTO>().ReverseMap();
    }
}
