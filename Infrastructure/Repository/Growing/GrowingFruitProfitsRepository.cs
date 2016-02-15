using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingFruitProfitsRepository : BaseRepository<GrowingFruitProfits>, IGrowingFruitProfitsRepository
    {
        public GrowingFruitProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
