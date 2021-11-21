using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Contracts
{
    public class NeededProductDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
