using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{
     public interface IHoneyTypeRepository : IRepositoryAsync<HoneyType>, IDisposable
    {    
    }

}
