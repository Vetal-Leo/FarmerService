using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingCulturesRepository : BaseRepository<GrowingCultures>, IGrowingCulturesRepository
    {
        public GrowingCulturesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
