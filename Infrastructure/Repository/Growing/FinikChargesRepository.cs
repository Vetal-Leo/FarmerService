using System.Data.Entity;
using Domain.Entities.Growing.FruitGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FinikChargesRepository : BaseRepository<FinikCharges>, IFinikChargesRepository
    {
        public FinikChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
