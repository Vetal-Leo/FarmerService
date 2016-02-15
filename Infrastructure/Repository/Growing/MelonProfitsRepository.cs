using System.Data.Entity;
using Domain.Entities.Growing.FieldGrowing;
using Infrastructure.Interfaces.Growing;

namespace Infrastructure.Repository.Growing
{
    public class MelonProfitsRepository : BaseRepository<MelonProfit>, IMelonProfitsRepository
    {
        public MelonProfitsRepository(DbContext context)
             : base(context)
        {
        }

       
    }

}
