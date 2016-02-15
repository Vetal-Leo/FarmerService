using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class OliveProfitsRepository : BaseRepository<OliveProfit>, IOliveProfitsRepository
    {
        public OliveProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
