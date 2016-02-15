using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TernProfitsRepository : BaseRepository<TernProfit>, ITernProfitsRepository
    {
        public TernProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
