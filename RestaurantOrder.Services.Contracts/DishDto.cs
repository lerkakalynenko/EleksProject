using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantOrder.Services.Contracts
{
    public class DishDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name of dish")]
        [RegularExpression(@"[A-z]*", ErrorMessage = "Not valid name for dish")]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter the price of dish")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public ICollection<NeededProductDto> NeededProductsDto { get; set; }

        public bool IsContainingInOrder { get; set; }

        public DishDto()
        {
            NeededProductsDto = new List<NeededProductDto>();
        }


    }
}
