using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
     public interface IBreedingDailyProfitRepository : IRepositoryAsync<BreedingDailyProfit>, IDisposable
    {    
    }

}
