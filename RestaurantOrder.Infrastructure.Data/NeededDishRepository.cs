using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;

namespace RestaurantOrder.Infrastructure.Data
{
    public class NeededDishRepository : INeededDishRepository
    {
        private readonly ApplicationContext context;
        private readonly DbSet<NeededDish> dbSet;
        public NeededDishRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<NeededDish>();
        }
        public NeededDish Create(NeededDish neededDish)
        {
            var result = context.Add(neededDish);
            context.SaveChanges();
            return result.Entity;
        }

        public NeededDish GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public ICollection<NeededDish> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
