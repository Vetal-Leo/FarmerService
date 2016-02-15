using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FinikProfitsRepository : BaseRepository<FinikProfit>, IFinikProfitsRepository
    {
        public FinikProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
