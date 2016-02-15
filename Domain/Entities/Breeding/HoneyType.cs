using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    [Table("HoneyType")]
    public class HoneyType : BaseEntity, IEntity<int>
    {
        #region Properties

        public string Name { get; set; }
        #endregion
  
    }


}
