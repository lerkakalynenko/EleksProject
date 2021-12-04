
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantOrder.Services.Contracts

{
    public class OrderDto
    {
        private int _tableNumber;


        public int OrderId { get; set; }

        public int TableNumber
        {
            get => _tableNumber;
            set
            {
                
                if (value is < 1 or > 30)
                {
                    throw new ArgumentException("Number of table must be from 1 to 30", nameof(value));
                }

                _tableNumber = value;
            }
        }

        public string Notes { get; set; }

        public ICollection<NeededDishDto> NeededDishes { get; set; }

        public decimal Sum => NeededDishes.Sum(neededDish => neededDish.Dish.Price);

        public OrderDto()
        {
            NeededDishes = new List<NeededDishDto>();
        }
    }
}
