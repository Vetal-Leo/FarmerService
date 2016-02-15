using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
     public interface IBreedingCulturesRepository : IRepositoryAsync<BreedingCultures>, IDisposable
    {      
    }

}
