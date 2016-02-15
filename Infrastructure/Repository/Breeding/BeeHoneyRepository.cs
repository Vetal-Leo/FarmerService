using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BeeHoneyRepository : BaseRepository<BeeHoney>, IBeeHoneyRepository
    {
        public BeeHoneyRepository(DbContext context)
             : base(context)
        {
        }
    }

}
