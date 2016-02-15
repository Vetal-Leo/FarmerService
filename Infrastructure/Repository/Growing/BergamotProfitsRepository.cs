using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BergamotProfitsRepository : BaseRepository<BergamotProfit>, IBergamotProfitsRepository
    {
        public BergamotProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
