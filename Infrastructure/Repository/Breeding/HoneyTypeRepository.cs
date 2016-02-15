using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class HoneyTypeRepository : BaseRepository<HoneyType>, IHoneyTypeRepository
    {
        public HoneyTypeRepository(DbContext context)
             : base(context)
        {
        }
    }

}
