using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Infrastructure.Data
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationContext context;
        private readonly DbSet<Dish> dbSet;
        private readonly DbSet<NeededDish> neededDishSet;

        public DishRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<Dish>();
            neededDishSet = context.Set<NeededDish>();
        }

        public Dish Create(Dish dish)
        {
            var result = context.Add(dish);
            context.SaveChanges();
            return result.Entity;
        }

        public Dish GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<Dish> GetAll()
        {
            return dbSet.ToList();
        }
        public void Delete(int id)
        {

            var neededDishes = neededDishSet.ToList();
            var entity = neededDishes.First(nDish => nDish.Dish.Id == id);
            neededDishSet.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Dish dish)
        {
            dbSet.Update(dish);
            context.SaveChanges();
        }
    }


}