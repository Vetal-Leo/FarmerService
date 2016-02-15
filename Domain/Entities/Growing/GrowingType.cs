using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.Growing
{
    [Table("GrowingType")]
    public class GrowingType : BaseEntity, IEntity<int>
    {
        #region Properties

        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingCultures> GrowingCultureses { get; set; }

        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingFieldComings> GrowingFieldComingses { get; set; }

        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingFruitComings> GrowingFruitComingses { get; set; }

        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingCharges> GrowingChargeses { get; set; }

        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingFieldProfits> GrowingFieldProfitses { get; set; }

        [InverseProperty("GrowingType")]
        public virtual ICollection<GrowingFruitProfits> GrowingFruitProfitses { get; set; }
        #endregion
    }


}
