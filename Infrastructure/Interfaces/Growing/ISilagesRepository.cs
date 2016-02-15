using System;
using Domain.Entities.Growing.FieldGrowing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface ISilagesRepository : IRepositoryAsync<Silages>, IDisposable
    {
      
    }


}
