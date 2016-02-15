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


        #region MelonComings

        public List<GrowingFieldComings> GetMelonComings(int userId)
        {
            return Calculate(_growingFieldComingsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Melon").ToList());
        }

        public async Task AddNewMelon(int userId, FormCollection collection)
        {
            var groving = new GrowingFieldComings
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Melon"),
                LandingDate = DateTime.Parse(collection[1]),
                CultureType = collection[2],
                Name = collection[3],
                MassType = collection[4],
                CurrencyType = collection[5],
                Cost = Convert.ToDecimal(collection[6].Replace(".", ",")),
                Amount = Convert.ToDecimal(collection[7].Replace(".", ",")),
                Document = FileNameValidator(collection[8])
            };

            _growingFieldComingsRepository.Add(groving);
            var culturetype = collection[2];
            var name = collection[3];
            var firstOrDefault = _growingFieldComingsRepository.Get().FirstOrDefault(c => c.CultureType == culturetype && c.Name == name);
            if (firstOrDefault != null)
            {
                var profit = new GrowingFieldProfits
                {
                    Id = firstOrDefault.Id,
                    CultureType = collection[2],
                    Name = collection[3],
                    ExpirationDate = GetExpirationDateForMelonCulture(DateTime.Parse(collection[1]), collection[2]),
                    Remind = false,
                    User = _usersRepository.Get().FirstOrDefault(i => i.Id == userId),
                    GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Melon")
                };
                await _growingFieldProfitsRepository.AddAsync(profit);
            }
        }

        private static DateTime? GetExpirationDateForMelonCulture(DateTime landingdate, string culturetype)
        {

            switch (culturetype)
            {
                case "Лук":
                    return landingdate.AddDays(75);
                case "Чеснок":
                    return landingdate.AddDays(100);
                case "Томат":
                    return landingdate.AddDays(70);
                case "Перец овощной":
                    return landingdate.AddDays(140);
                case "Баклажан":
                    return landingdate.AddDays(130);
                case "Тыква":
                    return landingdate.AddDays(110);
                case "Кабачок":
                    return landingdate.AddDays(40);
                case "Огурец":
                    return landingdate.AddDays(40);
                case "Патиссон":
                    return landingdate.AddDays(46);
                case "Дыня":
                    return landingdate.AddDays(80);
                case "Арбуз":
                    return landingdate.AddDays(45);
                case "Артишок":
                    return landingdate.AddDays(180);
                case "Спаржа":
                    return landingdate.AddDays(60);
                case "Ревень":
                    return landingdate.AddDays(40);
            }
            return DateTime.Now;
        }


        public GrowingFieldComings GetMelonComingById(int id)
        {

            var picked = _growingFieldComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            return new GrowingFieldComings
            {
                LandingDate = picked.LandingDate,
                CultureType = picked.CultureType,
                Name = picked.Name,
                MassType = picked.MassType,
                CurrencyType = picked.CurrencyType,
                Cost = picked.Cost,
                Amount = picked.Amount,
                Document = picked.Document,
                GrowingCultureses = _growingCulturesRepository.Get().Where(c => c.GrowingType.Name == "Melon")
            };
        }

        public async Task AddNewMelonById(int id, FormCollection collection)
        {
            var picked = _growingFieldComingsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.LandingDate = DateTime.Parse(collection[1]);
            picked.CultureType = collection[2];
            picked.Name = collection[3];
            picked.MassType = collection[4];
            picked.CurrencyType = collection[5];
            picked.Cost = Convert.ToDecimal(collection[6].Replace(".", ","));
            picked.Amount = Convert.ToDecimal(collection[7].Replace(".", ","));
            picked.Document = FileNameValidator(collection[8]);

            var pickedprofit = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            pickedprofit.CultureType = collection[2];
            pickedprofit.Name = collection[3];
            pickedprofit.ExpirationDate = GetExpirationDateForBreadCulture(DateTime.Parse(collection[1]), collection[2]);

            await _growingFieldComingsRepository.UpdateAsync(picked);
            await _growingFieldProfitsRepository.UpdateAsync(pickedprofit);
        }


        public void DeleteMelonById(int id)
        {
            _growingFieldProfitsRepository.Delete(id);
            _growingFieldComingsRepository.Delete(id);
        }
        #endregion



        #region MelonCharges

        public List<GrowingCharges> GetMelonCharges(int userId)
        {
            return Calculate(_growingChargesRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Melon").ToList());
        }



        public List<string> GetMelonNamesById(int id)
        {
            var grovings = _growingFieldComingsRepository.Get().Where(i => i.User.Id == id && i.GrowingType.Name == "Melon").ToList();
            return grovings.Select(item => item.Name).ToList();
        }

        public async Task AddNewMelonCharges(int id, FormCollection collection)
        {
            var charges = new GrowingCharges
            {
                User = _usersRepository.Get().FirstOrDefault(i => i.Id == id),
                GrowingType = _growingTypeRepository.Get().FirstOrDefault(i => i.Name == "Melon"),
                ApplicationDate = DateTime.Parse(collection[1]),
                PlantName = collection[2],
                Name = collection[3],
                Document = FileNameValidator(collection[4]),
                TotalCost = Convert.ToDecimal(collection[5].Replace(".", ",")),
            };

            await _growingChargesRepository.AddAsync(charges);
        }


        public GrowingCharges GetMelonChargesById(int id)
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

        public async Task AddNewMelonChargesById(int id, FormCollection collection)
        {
            var picked = _growingChargesRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ApplicationDate = DateTime.Parse(collection[1]);
            picked.PlantName = collection[2];
            picked.Name = collection[3];
            picked.Document = FileNameValidator(collection[4]);
            picked.TotalCost = Convert.ToDecimal(collection[5].Replace(".", ","));

            await _growingChargesRepository.UpdateAsync(picked);
        }


        public void DeleteMelonChargesById(int id)
        {
            _growingChargesRepository.Delete(id);
        }

        #endregion



        #region MelonProfits

        public List<GrowingFieldProfits> GetMelonProfits(int userId)
        {
            return Calculate(_growingFieldProfitsRepository.Get().Where(i => i.User.Id == userId && i.GrowingType.Name == "Melon").ToList(), userId);
        }

        public GrowingFieldProfits GetMelonProfitById(int id)
        {
            var picked = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];

            return new GrowingFieldProfits
            {
                ExpirationDate = picked.ExpirationDate,
                Remind = picked.Remind,
                MassType = picked.MassType,
                Amount = picked.Amount,
                Cost = picked.Cost,
                Document = picked.Document
            };
        }

        public async Task AddNewMelonProfitById(int id, FormCollection collection)
        {
            var picked = _growingFieldProfitsRepository.Get().Where(i => i.Id == id).ToList()[0];
            picked.ExpirationDate = DateTime.Parse(collection[1]);
            var remind = collection[2].Split(',')[0];
            picked.Remind = Convert.ToBoolean(remind);
            picked.MassType = collection[3];
            picked.Amount = Convert.ToDecimal(collection[4].Replace(".", ","));
            picked.Cost = Convert.ToDecimal(collection[5].Replace(".", ","));
            picked.Document = FileNameValidator(collection[6]);

            await _growingFieldProfitsRepository.UpdateAsync(picked);
        }

        #endregion

    }
}
