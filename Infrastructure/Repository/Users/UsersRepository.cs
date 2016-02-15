using System.Data.Entity;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.Interfaces.Users;

namespace Infrastructure.Repository.Users
{
    public class UsersRepository :
      BaseRepository<FarmerUser>,
      IUsersRepository
    {
        public UsersRepository(DbContext context)
            : base(context)
        {

        }
    }


}
