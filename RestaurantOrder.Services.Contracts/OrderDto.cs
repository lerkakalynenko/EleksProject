
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Contracts

{
    public class OrderDto
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Enter the number of table")]
        [Range(1,20, ErrorMessage = "The number of table must be from 1 to 20")]
        public int TableNumber { get; set; }
        [AllowNull]
        public string Notes { get; set; }
        public ICollection<NeededDishDto> NeededDishesDtos { get; set; }
    }
}
