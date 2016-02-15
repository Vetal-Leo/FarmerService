using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingTypeRepository : BaseRepository<GrowingType>, IGrowingTypeRepository
    {
        public GrowingTypeRepository(DbContext context)
             : base(context)
        {
        }
    }

}
