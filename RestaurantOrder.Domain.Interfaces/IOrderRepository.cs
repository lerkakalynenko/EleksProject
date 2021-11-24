using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
