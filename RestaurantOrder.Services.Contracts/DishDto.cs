using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantOrder.Services.Contracts
{
    public class DishDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<NeededProductDto> NeededProductsDto { get; set; }

        public DishDto()
        {
            NeededProductsDto = new List<NeededProductDto>();
        }


    }
}
