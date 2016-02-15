using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.Growing
{
    public class GrowingCultures : BaseEntity, IEntity<int>
    {
       
        #region Properties

        public string Name { get; set; }
        [Column("GrowingTypeId")]
        public GrowingType GrowingType { get; set; }
        #endregion

    }
}
