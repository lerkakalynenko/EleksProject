using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Domain.Interfaces
{
    public interface INeededProductRepository 
    {
        public NeededProduct Create(NeededProduct neededProduct);
        public NeededProduct GetById(int id);
        public void Delete(int id);
    }
}
