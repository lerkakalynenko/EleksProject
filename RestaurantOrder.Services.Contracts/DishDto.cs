using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Services.Contracts
{
    public class DishDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name of dish", AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the price of dish")]
        [Range(1, 10000, ErrorMessage = "Price must be from 1 to 10 000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<NeededProductDto> NeededProducts { get; set; }
        // public bool IsContainingInOrder { get; set; }
        public DishDto()
        {
            NeededProducts = new List<NeededProductDto>();
        }
        

    }
}
