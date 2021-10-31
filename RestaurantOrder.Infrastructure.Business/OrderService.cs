using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;
namespace RestaurantOrder.Infrastructure.Business
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;

        public Order CreateOrder(Order order)
        {
            return repository.Create(order);
        }

        public Order GetOrderById(int id)
        {
            return repository.GetById(id);
        }

        public void DeleteOrder(int id)
        {
            repository.Delete(id);
        }
    }
}
