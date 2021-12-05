using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RestaurantOrder.Domain.Core;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;

namespace RestaurantOrder.Infrastructure.Data
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationContext context;
        private readonly DbSet<Order> dbSet;
        private readonly DbSet<NeededDish> neededDishes;
        public OrderRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<Order>();
        }
        public Order Create(Order order)
        {
            var result = context.Add(order);
            context.SaveChanges();
            return result.Entity;
        }

        public Order GetById(int id)
        {
            return dbSet.Find(id);
        }

        
        public void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            dbSet.Update(order);
            context.SaveChanges();
        }

        public ICollection<Order> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
