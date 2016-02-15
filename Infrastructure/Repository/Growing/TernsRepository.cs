using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TernsRepository : BaseRepository<Terns>, ITernsRepository
    {
        public TernsRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
