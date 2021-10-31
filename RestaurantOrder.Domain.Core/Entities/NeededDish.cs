using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Domain.Core.Entities
{
     public class NeededDish
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public int DishQuantity { get; set; }
    }
}
