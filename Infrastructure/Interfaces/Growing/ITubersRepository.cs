using System;
using Domain.Entities.Growing.FieldGrowing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface ITubersRepository : IRepositoryAsync<Tubers>, IDisposable
    {
      
    }


}
