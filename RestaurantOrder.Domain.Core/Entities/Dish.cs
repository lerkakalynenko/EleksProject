using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantOrder.Domain.Core.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public virtual ICollection<NeededProduct> NeededProducts { get; set; }

        public Dish()
        {
            NeededProducts = new List<NeededProduct>();
        }

    }
}
