using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Growing
{
    public class GrowingFruitProfits : BaseEntity, IEntity<int>
    {
        #region Properties
        [Key]
        [ForeignKey("GrowingFruitComings")]
        [Column("GrowingFruitId")]  
        public new int Id { get; set; }
        [Column("GrowingTypeId")]
        public GrowingType GrowingType { get; set; }

        [Display(Name = "Тип культуры")]
        public string CultureType { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Средняя дата сбора урожая(получена от даты цветения)")]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Напоминать о сборе культуры")]
        public bool Remind { get; set; }
        [Display(Name = "Тип массы/штуки")]
        public string MassType { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Стоимость 1 ед.массы")]
        public decimal? Cost { get; set; }
        [Display(Name = "Документ выращенной культуры(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Полученная прибыль (чистая)")]
        public decimal? ClearCost { get; set; }
        [Display(Name = "Полученная прибыль (с учетом всех затрат)")]
        public decimal? ProfitCost { get; set; }
        [Column("UserId")]
        public FarmerUser User { get; set; }
        #endregion
        #region Navigation Property

        public virtual GrowingFruitComings GrowingFruitComings { get; set; }
        public IEnumerable<GrowingCultures> GrowingCultureses { get; set; }
        #endregion
    }
}
