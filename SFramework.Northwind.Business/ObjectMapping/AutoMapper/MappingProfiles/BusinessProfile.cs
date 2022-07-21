using AutoMapper;
using SFramework.Northwind.Entities.Concrete;

namespace SFramework.Northwind.Business.ObjectMapping.AutoMapper.MappingProfiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.QuantityPerUnit, opt => opt.MapFrom(src => src.QuantityPerUnit))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice));
        }
    }
}
