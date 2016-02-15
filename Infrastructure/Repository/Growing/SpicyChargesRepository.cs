using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SpicyChargesRepository : BaseRepository<SpicyCharges>, ISpicyChargesRepository
    {
        public SpicyChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
