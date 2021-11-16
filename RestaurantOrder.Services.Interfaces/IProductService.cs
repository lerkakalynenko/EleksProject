using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(Product product);
        public Product GetProductById(int id);
        public ICollection<Product> GetAll();
        public void DeleteProduct(int id);

    }
}
