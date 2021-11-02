using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Interfaces
{
    public interface INeededProductService
    {
        public NeededProduct Create(NeededProduct neededProduct);
        public NeededProduct GetById(int id);
        public void Delete(int id);
    }
}
