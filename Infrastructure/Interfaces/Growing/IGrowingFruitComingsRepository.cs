using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
  
    public interface IGrowingFruitComingsRepository : IRepositoryAsync<GrowingFruitComings>, IDisposable
    {    
    }

}
