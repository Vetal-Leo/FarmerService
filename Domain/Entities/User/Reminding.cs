using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.User
{
    [Table("Reminding")]
    public class Reminding : BaseEntity, IEntity<int>
    {
        #region Properties

        [Column("UserId")]
        public FarmerUser User { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата напоминания")]
        public DateTime? ExpirationDate { get; set; }

        #endregion

    }
}
