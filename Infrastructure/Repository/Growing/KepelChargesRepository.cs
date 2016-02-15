using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class KepelChargesRepository : BaseRepository<KepelCharges>, IKepelChargesRepository
    {
        public KepelChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
