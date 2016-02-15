using Domain.Context;
using Domain.Entities;
using Domain.Entities.Identity;
using Domain.Entities.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Infrastructure.Stores
{
    public class ApplicationUserStore : UserStore<FarmerUser, Role, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUserStore(DatabaseContext context)
            : base(context)
        {

        }
    }
}
