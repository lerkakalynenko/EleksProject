using System.Collections.Generic;

namespace RestaurantOrder.Domain.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public string Notes { get; set; }
        public ICollection<NeededDish> NeededDishes { get; set; }
        public Order()
        {
            NeededDishes = new List<NeededDish>();
        }
    }
}
