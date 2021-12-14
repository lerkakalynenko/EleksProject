using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface IDishRepository
    {
        public Dish Create(Dish dish);
        public Dish GetById(int id);
        public IEnumerable<Dish> GetAll();
        public void Delete(int id);
        public void Update(Dish dish);

    }
}
