using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;

namespace RestaurantOrder.Infrastructure.Data
{
    public class NeededProductRepository : INeededProductRepository
    {
        private readonly ApplicationContext context;
        private readonly DbSet<NeededProduct> dbSet;
        public NeededProductRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<NeededProduct>();
        }

        public NeededProduct Create(NeededProduct neededProduct)
        {
            var result = context.Add(neededProduct);
            context.SaveChanges();
            return result.Entity;
        }

        public NeededProduct GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }
    }
}
