using AutoMapper;
using Dtos;
using Dtos.Request;
using Dtos.Response;
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
            CreateMap<CreateVariantDto, Variant>();
            CreateMap<UpdateCartRequestDto, Cart>();
            CreateMap<UpdateCategoryRequestDto, Category>();
            CreateMap<CreateInvoiceRequestDto, Invoice>();
            CreateMap<UpdateInvoiceRequestDto, Invoice>();
            CreateMap<InvoiceVariantDto, InvoiceVariant>();
            CreateMap<CreateRatingRequestDto, Rating>();
            CreateMap<UpdateRatingRequestDto, Rating>();
            CreateMap<Cart, GetListCartResponse>();
            CreateMap<Variant, GetListCartVariantResponse>();
            CreateMap<Product, GetListCartProductResponse>();
            CreateMap<UpdateUserRequestDto, User>();
            CreateMap<User, GetUserInfoResponse>().ForMember(i => i.DateOfBirth, o => o.MapFrom(src => DateTime.Parse(src.DateOfBirth.ToString())));
            CreateMap<User, LoggedInResponse>().ForMember(i => i.DateOfBirth, o => o.MapFrom(src => DateTime.Parse(src.DateOfBirth.ToString())));
        }
    }
}
