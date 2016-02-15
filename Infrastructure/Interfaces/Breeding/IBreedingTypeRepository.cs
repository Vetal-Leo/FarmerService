using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
     public interface IBreedingTypeRepository : IRepositoryAsync<BreedingType>, IDisposable
    {      
    }

}
