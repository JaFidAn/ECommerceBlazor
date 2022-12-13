using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceDataAccess;
using ECommerceDataAccess.ViewModel;
using ECommercyModels.DTOs;

namespace ECommerceBusiness.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap(); //ReverseMapp will Map from CategoryDTO to Category
            CreateMap<Product, ProductDTO>().ReverseMap(); //ReverseMapp will Map from ProductDTO to Product
            CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap(); //ReverseMapp will Map from ProductPriceDTO to ProductPrice
            CreateMap<OrderHeaderDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}