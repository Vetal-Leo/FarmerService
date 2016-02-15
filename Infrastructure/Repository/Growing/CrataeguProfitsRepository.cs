using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class CrataeguProfitsRepository : BaseRepository<CrataeguProfit>, ICrataeguProfitsRepository
    {
        public CrataeguProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
