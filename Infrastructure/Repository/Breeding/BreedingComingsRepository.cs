using System.Data.Entity;
using Domain.Entities.Breeding;
using Infrastructure.Interfaces.Breeding;

namespace Infrastructure.Repository.Breeding
{
    public class BreedingComingsRepository : BaseRepository<BreedingComings>, IBreedingComingsRepository
    {
        public BreedingComingsRepository(DbContext context)
             : base(context)
        {
        } 
    }
}
