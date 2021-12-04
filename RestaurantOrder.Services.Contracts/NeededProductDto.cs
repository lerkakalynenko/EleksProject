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
        private int _quantity;

        public int Id { get; set; }
        public ProductDto Product { get; set; }

        public int ProductQuantity
        {
            get => _quantity;
            set
            {
                if (value is 0)
                {
                    throw new ArgumentException("Quantity of needed product must not be 0", nameof(value));
                }

                _quantity = value;
            }
        }
    }
}
