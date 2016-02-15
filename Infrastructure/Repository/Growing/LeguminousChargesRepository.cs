using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class LeguminousChargesRepository : BaseRepository<LeguminousCharges>, ILeguminousChargesRepository
    {
        public LeguminousChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
