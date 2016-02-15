using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingFruitComingsRepository : BaseRepository<GrowingFruitComings>, IGrowingFruitComingsRepository
    {
        public GrowingFruitComingsRepository(DbContext context)
             : base(context)
        {
        }

    }

}
