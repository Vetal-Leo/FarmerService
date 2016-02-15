using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class KepelProfitsRepository : BaseRepository<KepelProfit>, IKepelProfitsRepository
    {
        public KepelProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
