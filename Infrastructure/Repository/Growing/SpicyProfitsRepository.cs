using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SpicyProfitsRepository : BaseRepository<SpicyProfit>, ISpicyProfitsRepository
    {
        public SpicyProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
