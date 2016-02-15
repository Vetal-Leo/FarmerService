using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.User
{

    [Table("Profiles")]
    public  class Profile : BaseEntity, IEntity<int>
    {
        #region Properties
        [Key]
        [ForeignKey("User")]
        [Column("UserId")]
        public new int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string LastName { get; set; }
        [MaxLength(64)]
        public string Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
       
  
        #endregion

        #region Navigation Property

        public virtual FarmerUser User { get; set; }

        #endregion
    }
}
