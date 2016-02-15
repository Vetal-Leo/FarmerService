using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
  
     public interface IYoungBreedingRepository : IRepositoryAsync<YoungBreeding>, IDisposable
    {   
    }


}
