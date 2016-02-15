using System;
using Domain.Entities.Breeding;

namespace Infrastructure.Interfaces.Breeding
{

     public interface IBreedingRemindingRepository : IRepositoryAsync<BreedingReminder>, IDisposable
    {      
    }

}
