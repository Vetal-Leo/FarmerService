using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Growing
{
    public  class GrowingCharges : BaseEntity, IEntity<int>
    {
        [Column("UserId")]
        public FarmerUser User { get; set; }
        [Column("GrowingTypeId")]
        public GrowingType GrowingType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата применения")]
        public DateTime? ApplicationDate { get; set; }
        [Display(Name = "Название растения")]
        public string PlantName { get; set; }
        [Display(Name = "Название затраченного материала")]
        public string Name { get; set; }
        [Display(Name = "Документ затраченного материала(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Общая стоимость")]
        public decimal? TotalCost { get; set; }
        [Display(Name = "Сумма затрат для этой культуры")]
        public decimal? SumCost { get; set; }
    }


}
