using Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities.Identity
{
    public abstract class ApplicationRole : IdentityRole<int, ApplicationUserRole>, IEntity
    {
    }
}
