using System.Data.Entity;
using Domain.Entities;
using Domain.Entities.User;
using Infrastructure.Interfaces.Users;

namespace Infrastructure.Repository.Users
{
    public class ProfilesRepository :
     BaseRepository<Profile>,
     IProfilesRepository
    {
        public ProfilesRepository(DbContext context)
            : base(context)
        {

        }
    }
}
