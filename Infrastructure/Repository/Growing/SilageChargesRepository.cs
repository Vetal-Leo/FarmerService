using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class SilageChargesRepository : BaseRepository<SilageCharges>, ISilageChargesRepository
    {
        public SilageChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
