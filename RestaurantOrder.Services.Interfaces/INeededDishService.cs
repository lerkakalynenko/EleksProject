using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Interfaces
{
    public interface INeededDishService
    {
        public NeededDish Create(NeededDish neededDish);
        public NeededDish GetById(int id);
        public void Delete(int id);
    }
}
