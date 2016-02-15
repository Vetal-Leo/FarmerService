using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BeeComingsRepository : BaseRepository<BeeComings>, IBeeComingsRepository
    {
        public BeeComingsRepository(DbContext context)
             : base(context)
        {
        } 
    }
}
