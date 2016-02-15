using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BergamotChargesRepository : BaseRepository<BergamotCharges>, IBergamotChargesRepository
    {
        public BergamotChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
