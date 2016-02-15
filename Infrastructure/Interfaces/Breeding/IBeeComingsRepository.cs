using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
    public interface IBeeComingsRepository : IRepositoryAsync<BeeComings>, IDisposable
    {    
    }

}
