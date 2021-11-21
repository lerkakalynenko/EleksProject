using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface IProductRepository
    {
        public Product Create(Product product);
        public Product GetById(int id);
        public ICollection<Product> GetAll();
        public void Delete(int id);
    }
}
