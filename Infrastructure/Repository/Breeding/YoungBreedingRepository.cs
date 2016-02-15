using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class YoungBreedingRepository : BaseRepository<YoungBreeding>, IYoungBreedingRepository
    {
        public YoungBreedingRepository(DbContext context)
             : base(context)
        {
        }
    }

}
