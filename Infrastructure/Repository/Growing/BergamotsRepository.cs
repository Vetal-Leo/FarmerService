using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BergamotsRepository : BaseRepository<Bergamots>, IBergamotsRepository
    {
        public BergamotsRepository(DbContext context)
             : base(context)
        {

        }


    }


}
