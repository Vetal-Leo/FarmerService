using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public class BreedingCharges : BaseEntity, IEntity<int>
    {
        [Column("UserId")]
        public FarmerUser User { get; set; }
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата применения")]
        public DateTime? ApplicationDate { get; set; }
        [Display(Name = "Название животного/ рыбы/пчёл")]
        public string AnimalName { get; set; }
        [Display(Name = "Название затраченного материала или корма")]
        public string Name { get; set; }
        [Display(Name = "Документ затраченного материала или корма(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Общая стоимость")]
        public decimal? TotalCost { get; set; }
        [Display(Name = "Сумма затрат для этой особи(бей)/рыбы/пчёл")]
        public decimal? SumCost { get; set; }
    }


}
