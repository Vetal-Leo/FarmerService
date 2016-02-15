using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
    public interface IBreedingComingsRepository : IRepositoryAsync<BreedingComings>, IDisposable
    {    
    }

}
