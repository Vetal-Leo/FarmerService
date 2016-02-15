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


        #region CrataeguComings

        public List<GrowingFruitComings> GetCrataeguComings(int userId)
        {
            return Calculate(_growingFruitComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Crataegu").ToList());
        }


        public async Task AddNewCrataegu(int userId, FormCollection collection)
        {
            var bergamot = new GrowingFruitComings()
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Crataegu"),
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

            _growingFruitComingsRepository.Add(bergamot);
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
                    ExpirationDate = GetExpirationDateForCrataegu(DateTime.Parse(collection[2]), collection[3]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Crataegu")
                };
                await _growingFruitProfitsRepository.AddAsync(profit);
            }
        }


        private static DateTime? GetExpirationDateForCrataegu(DateTime floweringdate, string culturetype)
        {
            switch (culturetype)
            {
                case "Айва японская":
                    return floweringdate.AddDays(150);
                case "Актинидия коломикта":
                    return floweringdate.AddDays(75);
                case "Арония Мичурина":
                    return floweringdate.AddDays(90);
                case "Арония черноплодная":
                    return floweringdate.AddDays(90);
                case "Барбарис обыкновенный":
                    return floweringdate.AddDays(180);
                case "Боярышник кроваво-красный":
                    return floweringdate.AddDays(150);
                case "Боярышник крупноплодный":
                    return floweringdate.AddDays(150);
                case "Боярышник мексиканский":
                    return floweringdate.AddDays(150);
                case "Боярышник обыкновенный":
                    return floweringdate.AddDays(150);
                case "Боярышник перистонадрезанный":
                    return floweringdate.AddDays(150);
                case "Виноград амурский":
                    return floweringdate.AddDays(90);
                case "Виноград культурный":
                    return floweringdate.AddDays(105);
                case "Вишня войлочная":
                    return floweringdate.AddDays(45);
                case "Вишня кустарниковая":
                    return floweringdate.AddDays(105);
                case "Голубика":
                    return floweringdate.AddDays(40);
                case "Голубика высокорослая":
                    return floweringdate.AddDays(40);
                case "Гранат обыкновенный":
                    return floweringdate.AddDays(140);
                case "Гуарана":
                    return floweringdate.AddDays(120);
                case "Ежевика":
                    return floweringdate.AddDays(35);
                case "Ежевика вязолистная":
                    return floweringdate.AddDays(35);
                case "Ежевика гигантская":
                    return floweringdate.AddDays(35);
                case "Ежевика медвежья":
                    return floweringdate.AddDays(35);
                case "Ежевика обыкновенная":
                    return floweringdate.AddDays(35);
                case "Киви":
                    return floweringdate.AddDays(120);
                case "Кизил обыкновенный":
                    return floweringdate.AddDays(150);
                case "Кокона":
                    return floweringdate.AddDays(120);
                case "Крыжовник обыкновенный":
                    return floweringdate.AddDays(75);
            }
            return DateTime.Now;
        }

        public GrowingFruitComings GetCrataeguComingById(int id)
        {
            var picked = _growingFruitComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
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
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Crataegu")
            };
        }

        public async Task AddNewCrataeguById(int id, FormCollection collection)
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

        public void DeleteCrataeguById(int id)
        {
            _growingFruitProfitsRepository.Delete(id);
            _growingFruitComingsRepository.Delete(id);
        }

        #endregion





        #region CrataeguCharges

        public List<GrowingCharges> GetCrataeguCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Crataegu").ToList());
        }
        public List<string> GetCrataeguNamesById(int id)
        {
            var bergamots = _growingFruitComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Crataegu").ToList();
            return bergamots.Select(item => item.Name).ToList();
        }

        public async Task AddNewCrataeguCharges(int userId, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Crataegu"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }

        public GrowingCharges GetCrataeguChargesById(int id)
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

        public async Task AddNewCrataeguChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }

        public void DeleteCrataeguChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }
        #endregion



        #region CrataeguProfits

        public List<GrowingFruitProfits> GetCrataeguProfits(int userId)
        {
            return Calculate(_growingFruitProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Crataegu").ToList(), userId);
        }

        public GrowingFruitProfits GetCrataeguProfitById(int id)
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

        public async Task AddNewCrataeguProfitById(int id, FormCollection collection)
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
