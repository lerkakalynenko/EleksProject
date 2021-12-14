using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface INeededDishRepository
    {
        public NeededDish Create(NeededDish neededDish);
        public NeededDish GetById(int id);
        public void Delete(int id);
        public ICollection<NeededDish> GetAll();
    }
}
