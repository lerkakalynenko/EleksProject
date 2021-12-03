using Microsoft.AspNetCore.SignalR;

namespace RestaurantOrder.Domain.Core.Entities
{
     public class NeededDish
    {
        public int Id { get; set; }
        public virtual Dish Dish { get; set; }
        public int DishQuantity { get; set; }
        public int OrderId { get; set; }
        

    }
}
