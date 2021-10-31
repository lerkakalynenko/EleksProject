using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;


namespace RestaurantOrder.Services.Interfaces
{
    public interface IOrderService
    {
        public Order CreateOrder(Order order);
        public Order GetOrderById(int id);
        public void DeleteOrder(int id);


    }
}
