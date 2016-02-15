using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class OliveChargesRepository : BaseRepository<OliveCharges>, IOliveChargesRepository
    {
        public OliveChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
