using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingTypeRepository : BaseRepository<BreedingType>, IBreedingTypeRepository
    {
        public BreedingTypeRepository(DbContext context)
             : base(context)
        {
        }
    }

}
