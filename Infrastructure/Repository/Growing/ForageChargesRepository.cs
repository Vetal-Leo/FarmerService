using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class ForageChargesRepository : BaseRepository<ForageCharges>, IForageChargesRepository
    {
        public ForageChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
