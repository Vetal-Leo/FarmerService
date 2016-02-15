using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.User
{
    [Table("Photo")]
    public class Photo : BaseEntity, IEntity<int>
    {
        #region Properties

        [Key]
        [ForeignKey("User")]
        [Column("UserId")]
        public new int Id { get; set; }
        public string Avatar { get; set; }
        public string Growing { get; set; }
        public string Breeding { get; set; }     
        public string Technique { get; set; }
        public string Product { get; set; }
        #endregion

        #region Navigation Property

        public virtual FarmerUser User { get; set; }

        #endregion

    }
}


