using AutoMapper;
using Backend.Models.Clients;
using Backend.ViewModels.Clients;

namespace Backend.Helper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ClientViewModel, Clients>().ReverseMap();
    }
}