using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
    public interface IFishComingsRepository : IRepositoryAsync<FishComings>, IDisposable
    {    
    }

}
