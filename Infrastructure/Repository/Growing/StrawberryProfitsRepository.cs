using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class StrawberryProfitsRepository : BaseRepository<StrawberryProfit>, IStrawberryProfitsRepository
    {
        public StrawberryProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
