using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SilageProfitsRepository : BaseRepository<SilageProfit>, ISilageProfitsRepository
    {
        public SilageProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
