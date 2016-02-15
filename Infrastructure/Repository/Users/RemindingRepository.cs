using System.Data.Entity;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.Interfaces.Users;

namespace Infrastructure.Repository.Users
{
    public class RemindingRepository :
     BaseRepository<Reminding>,
     IRemindingRepository
    {
        public RemindingRepository(DbContext context)
            : base(context)
        {

        }


    }
}
