using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class FishComings : BaseEntity, IEntity<int>
    {
      
        #region Properties

        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        [Display(Name = "Дата разведения новой рыбы")]
        [DataType(DataType.Date)]
        public DateTime? ReceiptDate { get; set; }
        [Display(Name = "Вид рыбы")]
        public string CultureType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Тип массы/штуки")]
        public string MassType { get; set; }
        [Display(Name = "Тип валюты")]
        public string CurrencyType { get; set; }
        [Display(Name = "Стоимость 1 ед.массы")]
        public decimal? Cost { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Документ поступившей для разведения рыбы(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Общая стоимость")]
        public decimal? TotalCost { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }

        #endregion

        #region Navigation Properties

        [InverseProperty("FishComings")]
        public virtual FishProfits FishProfits { get; set; }
        public IEnumerable<BreedingCultures> BreedingCultureses { get; set; }
        #endregion
    }
}
