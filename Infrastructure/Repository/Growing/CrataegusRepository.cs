using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class CrataegusRepository : BaseRepository<Crataegus>, ICrataegusRepository
    {
        public CrataegusRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
