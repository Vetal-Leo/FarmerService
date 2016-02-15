using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Growing
{
    public class GrowingFieldComings : BaseEntity, IEntity<int>
    {
        #region Properties

        [Column("GrowingTypeId")]
        public GrowingType GrowingType { get; set; }
        [Display(Name = "Дата посадки")]
        [DataType(DataType.Date)]
        public DateTime? LandingDate { get; set; }
        [Display(Name = "Тип культуры")]
        public string CultureType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Тип массы")]
        public string MassType { get; set; }
        [Display(Name = "Тип валюты")]
        public string CurrencyType { get; set; }
        [Display(Name = "Стоимость 1 ед.массы")]
        public decimal? Cost { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Документ посадочного материала(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Общая стоимость")]
        public decimal? TotalCost { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }
    
        #endregion

        #region Navigation Properties
      
        [InverseProperty("GrowingFieldComings")]
        public virtual GrowingFieldProfits GrowingFieldProfits { get; set; }
        public IEnumerable<GrowingCultures> GrowingCultureses { get; set; }
        #endregion

    }
}
