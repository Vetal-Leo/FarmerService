using System.Data.Entity;
using Domain.Entities.Growing;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BreadProfitsRepository : BaseRepository<BreadProfit>, IBreadProfitsRepository
    {
        public BreadProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
