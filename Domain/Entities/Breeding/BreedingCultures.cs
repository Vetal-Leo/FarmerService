using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Growing;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class BreedingCultures : BaseEntity, IEntity<int>
    {
       
        #region Properties

        public string Name { get; set; }
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        #endregion

    }
}
