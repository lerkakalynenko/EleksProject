using System.Collections.Generic;

namespace RestaurantOrder.Services.Contracts
{
    public class ConnectionDishOrder
    {
        public OrderDto Order { get; set; }
        public IEnumerable<DishDto> Dishes { get; set; }
        public int Quantity { get; private set; }

        public ConnectionDishOrder(OrderDto order, IEnumerable<DishDto> dishes)
        {
            Order = order;
            Dishes = dishes;
        }

        public bool IsDishInOrder(int dishId)
        {
            foreach (var neededDish in Order.NeededDishes)
            {
                if (neededDish.Dish.Id == dishId)
                {
                    Quantity = neededDish.DishQuantity;
                    return true;
                }

            }

            return false;
        }

        
        
    }
}
