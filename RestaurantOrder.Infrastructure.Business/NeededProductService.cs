using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Infrastructure.Business
{   

    public class NeededProductService : INeededProductService
    {
        private readonly INeededProductRepository repository;

        public NeededProductService(INeededProductRepository neededProductRepository)
        {
            this.repository = neededProductRepository;
        }

        public NeededProduct Create(NeededProduct neededProduct)
        {
            return repository.Create(neededProduct);
        }

        public NeededProduct GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
