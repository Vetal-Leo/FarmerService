using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
    public interface IBreedingProfitRepository : IRepositoryAsync<BreedingProfits>, IDisposable
    {    
    }

}
