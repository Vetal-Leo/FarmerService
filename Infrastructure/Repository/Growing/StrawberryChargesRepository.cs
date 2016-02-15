using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class StrawberryChargesRepository : BaseRepository<StrawberryCharges>, IStrawberryChargesRepository
    {
        public StrawberryChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
