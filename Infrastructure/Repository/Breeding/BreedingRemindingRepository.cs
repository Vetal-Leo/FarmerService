using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingRemindingRepository : BaseRepository<BreedingReminder>, IBreedingRemindingRepository
    {
        public BreedingRemindingRepository(DbContext context)
             : base(context)
        {
        }
    }

}
