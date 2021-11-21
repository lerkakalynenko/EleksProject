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

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<NeededDish, NeededDishDto>();
            CreateMap<NeededDishDto, NeededDish>();

        }
    }
}
