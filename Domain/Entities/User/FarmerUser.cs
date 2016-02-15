using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities.Breeding;
using Domain.Entities.Growing;
using Microsoft.AspNet.Identity;

namespace Domain.Entities.User
{
    [Table("Users")]
    public  class FarmerUser : BaseUsersEntity
    {
        #region Properties

        public override string Email { get; set; }
        [Display(Name = "Состояние блокировки аккаунта")]
        public bool АccountBlocking { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string PasswordHash { get; set; }
        public override string PhoneNumber { get; set; }
        public bool Remind { get; set; }
        #endregion

        #region Navigation Properties
      
        [InverseProperty("User")]
        public virtual Profile Profile { get; set; }
        [InverseProperty("User")]
        public virtual Photo Photo { get; set; }


        //GROWING:
        [InverseProperty("User")]
        public virtual ICollection<GrowingFieldComings> GrowingFieldComingses{ get; set; }
        [InverseProperty("User")]
        public virtual ICollection<GrowingFruitComings> GrowingFruitComingses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<GrowingCharges> GrowingChargeses { get; set; }


        //BREEDING:
        [InverseProperty("User")]
        public virtual ICollection<YoungBreeding> YoungBreedings { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<BreedingComings> BreedingComingses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<BeeComings> BeeComingses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<FishComings> FishComingses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<BreedingCharges> BreedingChargeses { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<BreedingDailyProfit> BreedingDailyProfits { get; set; }

        #endregion


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<FarmerUser, int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }


}
