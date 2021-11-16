using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Contracts
{
    public class NeededDishDto
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public int DishQuantity { get; set; }
    }
}
