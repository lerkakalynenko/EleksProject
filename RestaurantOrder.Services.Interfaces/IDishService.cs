using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;


namespace RestaurantOrder.Services.Interfaces
{
    public interface IDishService
    {
        public Dish CreateDish(Dish dish);
        public Dish GetDishById(int id);
        public IEnumerable<Dish> GetAll();
        public void DeleteDish(int id);
    }
}
