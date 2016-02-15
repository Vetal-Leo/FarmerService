using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FodderChargesRepository : BaseRepository<FodderCharges>, IFodderChargesRepository
    {
        public FodderChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
