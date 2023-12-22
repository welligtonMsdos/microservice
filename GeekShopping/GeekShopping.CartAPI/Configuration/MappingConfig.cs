using AutoMapper;
using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Model;

namespace GeekShopping.CartAPI.Configuration;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<ProductVO, Product>().ReverseMap();
        CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
        CreateMap<CartDetailVO, CartDetail>().ReverseMap();
        CreateMap<CartVO, Cart>().ReverseMap();
    }
}
