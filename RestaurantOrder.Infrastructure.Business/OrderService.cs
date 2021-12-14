using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;
namespace RestaurantOrder.Infrastructure.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly INeededDishService _neededDishService;


        public OrderService(IOrderRepository orderRepository, INeededDishService neededDishService)
        {
            _repository = orderRepository;
            _neededDishService = neededDishService;
        }


        public Order CreateOrder(Order order)
        {
            return _repository.Create(order);
        }

        public Order GetOrderById(int id)
        {
            return _repository.GetById(id);
        }

        public void DeleteOrder(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Order order)
        {
            _repository.Update(order);
        }

        public ICollection<Order> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
