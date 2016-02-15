using System.Data.Entity;
using Domain.Entities.Growing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class GrowingFieldProfitsRepository : BaseRepository<GrowingFieldProfits>, IGrowingFieldProfitsRepository
    {
        public GrowingFieldProfitsRepository(DbContext context)
             : base(context)
        {
        }
    }

}
