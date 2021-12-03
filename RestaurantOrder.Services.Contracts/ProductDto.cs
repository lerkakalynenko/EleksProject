﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Services.Contracts
{
    public class ProductDto
    {
         public int Id { get; set; }
         [Required(ErrorMessage = "Enter the name of product")]
         [RegularExpression(@"[A-z]*", ErrorMessage = "!!!")]
         public string  Name { get; set; }
         [Range(0, 1000, ErrorMessage = "Quantity of product must be from 0 to 1000")]
         [Required(ErrorMessage = "Enter the quantity of product")]
         public int Quantity { get; set; }
    }

    
}
