using AutoMapper;
using Dtos;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateProductRequestDto, Product>();
            CreateMap<Product, UpdateProductRequestDto>();
            CreateMap<Category, UpdateCategoryRequestDto>();
            CreateMap<UpdateCategoryRequestDto, Category>();
        }
    }
}
