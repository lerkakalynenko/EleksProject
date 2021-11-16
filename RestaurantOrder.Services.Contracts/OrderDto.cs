
using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Contracts

{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int TableNumber { get; set; }
        public string Notes { get; set; }
        public ICollection<NeededDishDto> NeededDishesDtos { get; set; }
    }
}
