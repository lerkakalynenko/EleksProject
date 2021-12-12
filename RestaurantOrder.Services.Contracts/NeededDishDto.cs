using System;

namespace RestaurantOrder.Services.Contracts
{
     
    public class NeededDishDto
    {   //private Dish _dish;
        private int _quantity;
        public int Id { get; set; }
       
        public DishDto Dish { get; set; }
        
        public int DishQuantity { 
            get => _quantity; 
            set
            {
                if (value is 0) 
                {
                    throw new ArgumentException("Quantity of dish must not be 0", nameof(value));
                }

                _quantity = value;
            }
        }
        public int OrderId { get; set; }
    }
}
