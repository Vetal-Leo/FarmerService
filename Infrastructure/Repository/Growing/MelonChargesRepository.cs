using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class MelonsChargesRepository : BaseRepository<MelonCharges>, IMelonChargesRepository
    {
        public MelonsChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
