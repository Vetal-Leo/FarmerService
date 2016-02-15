using System;
using Domain.Entities.Growing.FieldGrowing;
using Domain.Entities.Growing.FruitGrowing;

namespace Infrastructure.Interfaces.Growing
{
  
     public interface IBergamotsRepository : IRepositoryAsync<Bergamots>, IDisposable
    {
      
    }


}
