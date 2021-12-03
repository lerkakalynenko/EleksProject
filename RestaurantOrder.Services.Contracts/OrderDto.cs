
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RestaurantOrder.Domain.Core.Entities;

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
                    throw new ArgumentException("Номер стола должен быть от 1 до 30.", nameof(value));
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
