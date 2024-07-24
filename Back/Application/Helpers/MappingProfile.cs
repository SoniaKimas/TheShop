using Application.Discounts;
using Application.Products;
using Domain;

namespace Application.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
  
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.UnitType, opt => opt.MapFrom(src => src.UnitType.ToString()));

        CreateMap<Discount, DiscountDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));

    }
}