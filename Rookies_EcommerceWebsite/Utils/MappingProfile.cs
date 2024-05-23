using AutoMapper;
using Dtos;
using Dtos.Request;
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
            CreateMap<CreateInvoiceRequestDto, Invoice>();
            CreateMap<UpdateInvoiceRequestDto, Invoice>();
            CreateMap<InvoiceVariantDto, InvoiceVariant>();
            CreateMap<CreateRatingRequestDto, Rating>();
            CreateMap<UpdateRatingRequestDto, Rating>();
            CreateMap<User, LoggedInResponse>().ForMember(i => i.DateOfBirth, o => o.MapFrom(src => DateTime.Parse(src.DateOfBirth.ToString())));
        }
    }
}
