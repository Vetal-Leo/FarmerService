using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class OlivesRepository : BaseRepository<Olives>, IOlivesRepository
    {
        public OlivesRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
