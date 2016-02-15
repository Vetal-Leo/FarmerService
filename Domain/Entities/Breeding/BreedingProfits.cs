using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class BreedingProfits : BaseEntity, IEntity<int>
    {
        #region Properties
        [Key]
        [ForeignKey("BreedingComings")]
        [Column("BreedingId")]  
        public new int Id { get; set; }
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }

        [Display(Name = "Порода")]
        public string CultureType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата ухода")]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Причина ухода")]
        public string Motive { get; set; }
        [Display(Name = "Тип массы/штуки")]
        public string MassType { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Стоимость 1 ед.массы/штуки")]
        public decimal? Cost { get; set; }
        [Display(Name = "Документ уходящей особи(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Полученная прибыль")]
        public decimal? ProfitCost { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }
        #endregion
        #region Navigation Property

       
        public virtual BreedingComings BreedingComings { get; set; }
        public IEnumerable<BreedingCultures> BreedingCultureses { get; set; }

        #endregion
    }
}
