using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SilagesRepository : BaseRepository<Silages>, ISilagesRepository
    {
        public SilagesRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
