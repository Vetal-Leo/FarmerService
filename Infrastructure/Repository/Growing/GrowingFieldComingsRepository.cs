using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingFieldComingsRepository : BaseRepository<GrowingFieldComings>, IGrowingFieldComingsRepository
    {
        public GrowingFieldComingsRepository(DbContext context)
             : base(context)
        {
        } 
    }
}
