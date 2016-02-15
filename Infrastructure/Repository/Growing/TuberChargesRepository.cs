using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class TuberChargesRepository : BaseRepository<TuberCharges>, ITuberChargesRepository
    {
        public TuberChargesRepository(DbContext context)
             : base(context)
        {
        }
    }

}
