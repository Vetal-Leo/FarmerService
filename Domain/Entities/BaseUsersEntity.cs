using System.ComponentModel.DataAnnotations;
using Domain.Entities.Identity;
using Domain.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public abstract class BaseUsersEntity : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IEntity<int>
    {
        [Key]
        public override int Id { get; set; }
    }
}
