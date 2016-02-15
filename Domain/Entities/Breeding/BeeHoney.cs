using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public  class BeeHoney : BaseEntity, IEntity<int>
    {
        #region Properties
        [Column("UserId")]
        public FarmerUser User { get; set; }
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата поступления мёда")]
        public DateTime? Date { get; set; }
        [Display(Name = "Название пчёл")]
        public string AnimalName { get; set; }
        [Display(Name = "Тип мёда")]
        public string HoneyType { get; set; }
        [Display(Name = "Тип объёма")]
        public string MassType { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Стоимость 1 ед.объёма")]
        public decimal? Cost { get; set; }
        [Display(Name = "Документ полученного мёда(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Полученная прибыль")]
        public decimal? ProfitCost { get; set; }

        #endregion
        #region Navigation Properties

        public IEnumerable<HoneyType> HoneyTypeses { get; set; }
        public IEnumerable<BreedingCultures> BreedingCultureses { get; set; }
        #endregion

    }
}
