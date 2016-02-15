using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingCulturesRepository : BaseRepository<BreedingCultures>, IBreedingCulturesRepository
    {
        public BreedingCulturesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
