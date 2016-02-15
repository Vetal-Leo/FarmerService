using System.Data.Entity;
using Domain.Entities.Growing;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BreadChargesRepository : BaseRepository<BreadCharges>, IBreadChargesRepository
    {
        public BreadChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
