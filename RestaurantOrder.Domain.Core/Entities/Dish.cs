using System.Collections.Generic;

namespace RestaurantOrder.Domain.Core.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<NeededProduct> NeededProducts { get; set; }

        public Dish()
        {
            NeededProducts = new List<NeededProduct>();
        }

    }
}
