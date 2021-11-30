using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace RestaurantOrder.Services.Contracts
{
    public class DishDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name of dish")]
        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter a price for dish")]
        [Range(0,maximum:10000, ErrorMessage = "Price must be from 0 to 10000") ]
        public decimal Price { get; set; }
        public ICollection<NeededProductDto> NeededProductsDtos { get; set; }
    }
}
