using AutoMapper;
using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Configuration;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<UserVO, User>().ReverseMap();
        CreateMap<UserResult, User>().ReverseMap();
        CreateMap<UserViewModel, User>().ReverseMap();
        CreateMap<UserViewModel, UserResult>().ReverseMap();
        CreateMap<UserViewModelWithId,  User>().ReverseMap();
    }
}
