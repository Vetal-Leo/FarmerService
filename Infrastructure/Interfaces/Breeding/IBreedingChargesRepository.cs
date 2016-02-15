using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
     public interface IBreedingChargesRepository : IRepositoryAsync<BreedingCharges>, IDisposable
    {      
    }

}
