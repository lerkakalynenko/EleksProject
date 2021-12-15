using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<NeededProduct> NeededProducts { get; set; }
        public DbSet<NeededDish> NeededDishes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();

        }
    }
    
}
