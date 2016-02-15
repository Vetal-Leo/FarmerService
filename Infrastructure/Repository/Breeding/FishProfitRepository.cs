using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class FishProfitRepository : BaseRepository<FishProfits>, IFishProfitRepository
    {
        public FishProfitRepository(DbContext context)
             : base(context)
        {
        }
    }

}
