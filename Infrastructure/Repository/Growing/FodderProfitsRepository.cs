using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FodderProfitsRepository : BaseRepository<FodderProfit>, IFodderProfitsRepository
    {
        public FodderProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
