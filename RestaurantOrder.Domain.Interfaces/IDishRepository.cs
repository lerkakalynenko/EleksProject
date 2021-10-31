using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface IDishRepository
    {
        public Dish Create(Dish dish);
        public Dish GetById(int id);
        public IEnumerable<Dish> GetAll();
        public void Delete(int id);


    }
}
