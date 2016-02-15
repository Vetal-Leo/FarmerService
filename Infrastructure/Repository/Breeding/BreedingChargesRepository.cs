using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingChargesRepository : BaseRepository<BreedingCharges>, IBreedingChargesRepository
    {
        public BreedingChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
