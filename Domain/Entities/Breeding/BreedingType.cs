using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    [Table("BreedingType")]
    public class BreedingType : BaseEntity, IEntity<int>
    {
        #region Properties

        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingCultures> BreedingCultureses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<YoungBreeding> YoungBreedings { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingComings> BreedingComingses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BeeComings> BeeComingses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<FishComings> FishComingses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingCharges> BreedingChargeses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingDailyProfit> BreedingDailyProfits { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BeeHoney> BeeHoneys { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingProfits> BreedingProfitses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<FishProfits> FishProfitses { get; set; }

        [InverseProperty("BreedingType")]
        public virtual ICollection<BreedingReminder> BreedingReminders { get; set; }
        #endregion
    }


}
