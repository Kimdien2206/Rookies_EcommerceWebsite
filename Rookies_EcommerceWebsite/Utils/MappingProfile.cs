using AutoMapper;
using Dtos;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductRequestDto, Product>();
            CreateMap<CreateCartRequestDto, Cart>();
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<UpdateProductRequestDto, Product>();
            CreateMap<UpdateCartRequestDto, Cart>();
            CreateMap<UpdateCategoryRequestDto, Category>();
            CreateMap<CreateVariantDto, Variant>();
            
        }
    }
}
