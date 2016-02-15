using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TuberProfitsRepository : BaseRepository<TuberProfit>, ITuberProfitsRepository
    {
        public TuberProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
