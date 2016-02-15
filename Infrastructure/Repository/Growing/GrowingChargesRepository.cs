using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingChargesRepository : BaseRepository<GrowingCharges>, IGrowingChargesRepository
    {
        public GrowingChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
