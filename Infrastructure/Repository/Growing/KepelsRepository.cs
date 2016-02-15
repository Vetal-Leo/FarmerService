using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class KepelsRepository : BaseRepository<Kepels>, IKepelsRepository
    {
        public KepelsRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
