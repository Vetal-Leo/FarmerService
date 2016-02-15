using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface IGrowingCulturesRepository : IRepositoryAsync<GrowingCultures>, IDisposable
    {    
    }

}
