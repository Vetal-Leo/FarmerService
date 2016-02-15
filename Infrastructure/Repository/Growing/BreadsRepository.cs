using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Entities.Growing;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class BreadsRepository : BaseRepository<Breads>, IBreadsRepository
    {
        public BreadsRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
