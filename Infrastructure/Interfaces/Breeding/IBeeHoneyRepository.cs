using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
     public interface IBeeHoneyRepository : IRepositoryAsync<BeeHoney>, IDisposable
    {    
    }

}
