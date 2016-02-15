using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class FishComingsRepository : BaseRepository<FishComings>, IFishComingsRepository
    {
        public FishComingsRepository(DbContext context)
             : base(context)
        {
        } 
    }
}
