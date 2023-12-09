using AutoMapper;
using GeekShopping.UserAPI.Data.ValueObjects;
using GeekShopping.UserAPI.Model;

namespace GeekShopping.UserAPI.Configuration;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<UserVO, User>().ReverseMap();
    }
}
