using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Models
{
    public class ViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<NeededDish> NeededDishes { get; set; }

        public decimal Sum => NeededDishes.Sum(neededDish => neededDish.Dish.Price);
            
    }
}
