using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class FoddersRepository : BaseRepository<Fodders>, IFoddersRepository
    {
        public FoddersRepository(DbContext context)
             : base(context)
        {

        }
   
    }


}
