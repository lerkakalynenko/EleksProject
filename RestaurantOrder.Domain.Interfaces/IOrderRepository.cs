using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    
    public interface IOrderRepository
    {
        public Order Create(Order order);
        public Order GetById(int id);
        public void Delete(int id);
        public void Update(Order order);
        public ICollection<Order> GetAll();
    }
}
