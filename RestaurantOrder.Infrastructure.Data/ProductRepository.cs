using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Domain.Core;
namespace RestaurantOrder.Infrastructure.Data
{
    
    public class ProductRepository: IProductRepository{
        private readonly ApplicationContext context;
        private readonly DbSet<Product> dbSet;
        public ProductRepository(ApplicationContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
            dbSet = context.Set<Product>();
        }
        public Product Create(Product product)
        {
            var result = context.Add(product);
            context.SaveChanges();
            return result.Entity;
        }

        public Product GetById(int id)
        {
            return dbSet.Find(id);
        }

        public ICollection<Product> GetAll()
        {
            return dbSet.ToList();
        }

        //public IEnumerable<Product> GetAll()
        //{
        //    return dbSet.ToList();
        //}
        public void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

    }
}
