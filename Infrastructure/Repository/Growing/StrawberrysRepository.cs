using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class StrawberrysRepository : BaseRepository<Strawberrys>, IStrawberrysRepository
    {
        public StrawberrysRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
