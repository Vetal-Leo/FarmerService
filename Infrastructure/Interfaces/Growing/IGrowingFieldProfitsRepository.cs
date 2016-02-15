using System;
using Domain.Entities.Growing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface IGrowingFieldProfitsRepository : IRepositoryAsync<GrowingFieldProfits>, IDisposable
    {    
    }


}
