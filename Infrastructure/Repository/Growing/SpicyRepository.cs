using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SpicyRepository : BaseRepository<Spicys>, ISpicyRepository
    {
        public SpicyRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
