using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;

namespace RestaurantOrder.Mappings
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Dish, DishDto>();
            CreateMap<DishDto, Dish>();

            CreateMap<NeededProduct, NeededProductDto>();
            CreateMap<NeededProductDto, NeededProduct>();
        }
    }
}
