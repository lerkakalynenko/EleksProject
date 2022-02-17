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

        public DishRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<Dish>();
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
            var entity = GetById(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Update(Dish dish)
        {
            dbSet.Update(dish);
            context.SaveChanges();
        }
    }


}