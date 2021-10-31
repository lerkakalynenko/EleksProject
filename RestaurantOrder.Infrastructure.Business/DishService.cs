using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Infrastructure.Business
{
    public class DishService : IDishService
    {
        private readonly IDishRepository repository;


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
    }
}
