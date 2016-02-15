using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingProfitRepository : BaseRepository<BreedingProfits>, IBreedingProfitRepository
    {
        public BreedingProfitRepository(DbContext context)
             : base(context)
        {
        }
    }

}
