using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Infrastructure.Business
{
    public class DishService : IDishService
    {
        private readonly IDishRepository repository;

        public DishService(IDishRepository dishRepository)
        {
            this.repository = dishRepository;
        }

        public Dish CreateDish(Dish dish)
        {
            return repository.Create(dish);
        }

        public Dish GetDishById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            return repository.GetAll();
        }

        public void DeleteDish(int id)
        {
            repository.Delete(id);
        }

        public void Update(Dish dish)
        {
            repository.Update(dish);
        }
    }
}
