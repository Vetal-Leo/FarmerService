using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TernChargesRepository : BaseRepository<TernCharges>, ITernChargesRepository
    {
        public TernChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
