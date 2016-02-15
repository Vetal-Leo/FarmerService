using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class BeeComings : BaseEntity, IEntity<int>
    {
        #region Properties

        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        [Display(Name = "Дата установки нового улия")]
        [DataType(DataType.Date)]
        public DateTime? ReceiptDate { get; set; }
        [Display(Name = "Порода пчёл")]
        public string CultureType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Тип валюты")]
        public string CurrencyType { get; set; }
        [Display(Name = "Стоимость 1 - го улия")]
        public decimal? Cost { get; set; }
        [Range(0.00, 10000000.00)]
        [Display(Name = "Колличество")]
        public int? Amount { get; set; }
        [Display(Name = "Документ поступившего нового улия(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Общая стоимость")]
        public decimal? TotalCost { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }
    
        #endregion

        #region Navigation Properties
      
        public IEnumerable<BreedingCultures> BreedingCultureses { get; set; }
        #endregion

    }
}
