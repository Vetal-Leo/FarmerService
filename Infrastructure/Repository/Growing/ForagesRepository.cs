using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class ForagesRepository : BaseRepository<Forages>, IForagesRepository
    {
        public ForagesRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
