using System;
using Domain.Entities.Growing.FruitGrowing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface IKepelsRepository : IRepositoryAsync<Kepels>, IDisposable
    {
      
    }


}
