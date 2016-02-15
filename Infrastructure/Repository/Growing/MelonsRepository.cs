using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class MelonsRepository : BaseRepository<Melons>, IMelonsRepository
    {
        public MelonsRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
