using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingDailyProfitRepository : BaseRepository<BreedingDailyProfit>, IBreedingDailyProfitRepository
    {
        public BreedingDailyProfitRepository(DbContext context)
             : base(context)
        {
        }
    }

}
