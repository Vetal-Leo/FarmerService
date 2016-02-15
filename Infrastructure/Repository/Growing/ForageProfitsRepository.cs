using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class ForageProfitsRepository : BaseRepository<ForageProfit>, IForageProfitsRepository
    {
        public ForageProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
