using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FiniksRepository : BaseRepository<Finiks>, IFiniksRepository
    {
        public FiniksRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
