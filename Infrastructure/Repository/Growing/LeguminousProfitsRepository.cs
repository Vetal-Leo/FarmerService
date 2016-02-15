using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class LeguminousProfitsRepository : BaseRepository<LeguminousProfit>, ILeguminousProfitsRepository
    {
        public LeguminousProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
