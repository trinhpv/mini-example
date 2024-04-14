using AutoMapper;
using MiniExample.Model.Models;
using MiniExample.Data.Entities;
using MiniExample.Model.Types.Product;

namespace Shopping.Service.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //source mapping to destination
            CreateMap<MakerEntity, Maker>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<MakerEntity, MakerInfo>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Maker, MakerEntity>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<ProductEntity, Product>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<Product, ProductEntity>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<ProductEntity, ProductResponseItem>().ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
