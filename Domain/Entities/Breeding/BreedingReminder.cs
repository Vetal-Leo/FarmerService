using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class BreedingReminder : BaseEntity, IEntity<int>
    {
        #region Properties
       
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }

        [Display(Name = "Название животного/рыбы/пчёл")]
        public string AnimalName { get; set; }
        [Display(Name = "Текст напоминания(что напомнить?)")]
        public string Text { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата напоминания")]
        public DateTime? RemindDate { get; set; }
        [Range(0.00, 10000000.00)]
        [Display(Name = "Сколько дней напоминать")]
        public int? RemindDays { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }
        #endregion
        #region Navigation Property

        public IEnumerable<BreedingCultures> BreedingCultureses { get; set; }
        #endregion
    }
}
