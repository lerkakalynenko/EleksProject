using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Product Create(Product product);
        public Product GetById(int id);
        public void Delete(int id);
    }
}
