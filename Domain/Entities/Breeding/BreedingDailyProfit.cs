using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.User;
using Domain.Interfaces;

namespace Domain.Entities.Breeding
{
    public  class BreedingDailyProfit : BaseEntity, IEntity<int>
    {
        [Column("UserId")]
        public FarmerUser User { get; set; }
        [Column("BreedingTypeId")]
        public BreedingType BreedingType { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        public DateTime? Date { get; set; }
        [Display(Name = "Название животного")]
        public string AnimalName { get; set; }
        [Display(Name = "Название полученной прибыли (молоко/яйца/шерсть/пух/перья/перевозка груза/прочие)")]
        public string Name { get; set; }
        [Display(Name = "Тип массы/объёма/штуки")]
        public string MassType { get; set; }
        [Display(Name = "Колличество")]
        public decimal? Amount { get; set; }
        [Display(Name = "Стоимость 1 ед.массы/ объёма")]
        public decimal? Cost { get; set; }
        [Display(Name = "Документ полученной прибыли(PDF)")]
        public string Document { get; set; }
        [Display(Name = "Суточная прибыль (чистая)")]
        public decimal? СlearCost { get; set; }
        [Display(Name = "Суточная прибыль (с учетом сегоднешних всех затрат)")]
        public decimal? ProfitCost { get; set; }
    }


}
