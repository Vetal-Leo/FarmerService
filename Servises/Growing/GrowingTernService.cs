using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Entities.Growing;

namespace Servises.Growing
{
    public partial class GrowingService
    {


        #region TernComings

        public List<GrowingFruitComings> GetTernComings(int userId)
        {
            return Calculate(_growingFruitComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tern").ToList());
        }


        public async Task AddNewTern(int userId, FormCollection collection)
        {
            var tern = new GrowingFruitComings()
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tern"),
                LandingDate = DateTime.Parse(collection[1]),
                FloweringDate = DateTime.Parse(collection[2]),
                CultureType = collection[3],
                Name = collection[4],
                MassType = collection[5],
                CurrencyType = collection[6],
                Cost = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Amount = Convert.ToDecimal(collection[8].Replace(".", ",")),
                Document = FileNameValidator(collection[9])
            };

            _growingFruitComingsRepository.Add(tern);
            var culturetype = collection[3];
            var name = collection[4];
            var firstOrDefault = _growingFruitComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new GrowingFruitProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[3],
                    Name = collection[4],
                    ExpirationDate = GetExpirationDateForTern(DateTime.Parse(collection[2]), collection[3]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tern")
                };
                await _growingFruitProfitsRepository.AddAsync(profit);
            }
        }


        private static DateTime? GetExpirationDateForTern(DateTime floweringdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Лещина крупная":
                    return floweringdate.AddDays(210);
                case "Лещина обыкновенная":
                    return floweringdate.AddDays(210);
                case "Малина":
                    return floweringdate.AddDays(30);
                case "Малина великолепная":
                    return floweringdate.AddDays(30);
                case "Малина майсурская":
                    return floweringdate.AddDays(30);
                case "Малина пурпурноплодная":
                    return floweringdate.AddDays(30);
                case "Малина розолистная":
                    return floweringdate.AddDays(30);
                case "Наранхилла":
                    return floweringdate.AddDays(120);
                case "Облепиха крушиновидная":
                    return floweringdate.AddDays(180);
                case "Пепино":
                    return floweringdate.AddDays(70);
                case "Слива карликовая":
                    return floweringdate.AddDays(135);
                case "Слива морская":
                    return floweringdate.AddDays(105);
                case "Смородина американская":
                    return floweringdate.AddDays(17);
                case "Смородина белая":
                    return floweringdate.AddDays(17);
                case "Смородина золотистая":
                    return floweringdate.AddDays(40);
                case "Смородина красная":
                    return floweringdate.AddDays(40);
                case "Смородина моховая":
                    return floweringdate.AddDays(45);
                case "Смородина скальная":
                    return floweringdate.AddDays(40);
                case "Смородина чёрная":
                    return floweringdate.AddDays(60);
                case "Смородина широколистная":
                    return floweringdate.AddDays(30);
                case "Смородина Янчевского":
                    return floweringdate.AddDays(75);
                case "Тёрн":
                    return floweringdate.AddDays(150);
                case "Шиповник Вудса":
                    return floweringdate.AddDays(30);
                case "Шиповник иглистый":
                    return floweringdate.AddDays(30);
                case "Шиповник майский":
                    return floweringdate.AddDays(75);
                case "Шиповник морщинистый":
                    return floweringdate.AddDays(40);
            }
            return DateTime.Now;
        }

        public GrowingFruitComings GetTernComingById(int id)
        {
            var picked = _growingFruitComingsRepository.Get().Where(i => i.Name == "Tern").ToList()[0];
            return new GrowingFruitComings
            {
                LandingDate = picked.LandingDate,
                FloweringDate = picked.FloweringDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Tern")
            };
        }

        public async Task AddNewTernById(int id, FormCollection collection)
        {
            var picked = _growingFruitComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.LandingDate = DateTime.Parse(collection[1]);
            picked.FloweringDate = DateTime.Parse(collection[2]);
            picked.CultureType = collection[3];
            picked.Name = collection[4];
            picked.MassType = collection[5];
            picked.CurrencyType = collection[6];
            picked.Cost = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Amount = Convert.ToDecimal(collection[8].Replace(".", ","));
            picked.Document = FileNameValidator(collection[9]);


            var pickedprofit = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[3];
            pickedprofit.Name = collection[4];
            pickedprofit.ExpirationDate = GetExpirationDateForBergamot(DateTime.Parse(collection[2]), collection[3]);

            await _growingFruitComingsRepository.UpdateAsync(picked);
            await _growingFruitProfitsRepository.UpdateAsync(pickedprofit);
        }

        public void DeleteTernById(int id)
        {
            _growingFruitProfitsRepository.Delete(id);
            _growingFruitComingsRepository.Delete(id);
        }

        #endregion





        #region TernCharges

        public List<GrowingCharges> GetTernCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tern").ToList());
        }
        public List<string> GetTernNamesById(int id)
        {
            var bergamots = _growingFruitComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Tern").ToList();
            return bergamots.Select(item => item.Name).ToList();
        }

        public async Task AddNewTernCharges(int userId, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Tern"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }

        public GrowingCharges GetTernChargesById(int id)
        {
            var picked = _growingChargesRepository.Get().FirstOrDefault(i => i.Id == id);

            if (picked != null)
                return new GrowingCharges
                {
                    ApplicationDate = picked.ApplicationDate,
                    PlantName = picked.PlantName,
                    Name = picked.Name,
                    Document = picked.Document,
                    TotalCost = picked.TotalCost
                };
            return null;
        }

        public async Task AddNewTernChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteTernChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }
        #endregion



        #region TernProfits

        public List<GrowingFruitProfits> GetTernProfits(int userId)
        {
            return Calculate(_growingFruitProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Tern").ToList(), userId);
        }

        public GrowingFruitProfits GetTernProfitById(int id)
        {
            var picked = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new GrowingFruitProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Remind = picked.Remind,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }

        public async Task AddNewTernProfitById(int id, FormCollection collection)
        {
            var picked = _growingFruitProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            var remind = collection[2].Split(',')[0];
            picked.Remind = Convert.ToBoolean(remind);
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _growingFruitProfitsRepository.UpdateAsync(picked);
        }

        #endregion


    }
}
