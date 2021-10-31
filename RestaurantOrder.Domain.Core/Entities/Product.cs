﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Domain.Core.Entities
{
    public class Product
    {   
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
