using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class LeguminousRepository : BaseRepository<Leguminous>, ILeguminousRepository
    {
        public LeguminousRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
