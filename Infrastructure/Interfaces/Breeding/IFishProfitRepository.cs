using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
    public interface IFishProfitRepository : IRepositoryAsync<FishProfits>, IDisposable
    {    
    }

}
