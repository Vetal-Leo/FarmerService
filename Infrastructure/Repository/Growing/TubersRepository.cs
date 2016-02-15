using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TubersRepository : BaseRepository<Tubers>, ITubersRepository
    {
        public TubersRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
