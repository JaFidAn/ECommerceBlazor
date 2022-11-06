using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceDataAccess;
using ECommercyModels.DTOs;

namespace ECommerceBusiness.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap(); //ReverseMapp will Map from CategoryDTO to Category
            CreateMap<Product, ProductDTO>().ReverseMap(); //ReverseMapp will Map from ProductDTO to Product
        }
    }
}