using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class CrataeguChargesRepository : BaseRepository<CrataeguCharges>, ICrataeguChargesRepository
    {
        public CrataeguChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
